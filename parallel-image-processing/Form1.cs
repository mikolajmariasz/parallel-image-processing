using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parallel_image_processing
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private readonly PictureBox[] processedPictureBoxes;
        private CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();

            processedPictureBoxes = new PictureBox[]
            {
                picProcessed1, picProcessed2, picProcessed3, picProcessed4
            };

            this.Resize += Form1_Resize;
            UpdateLayout();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            int size = Math.Min((this.ClientSize.Width - 40) / 2, (this.ClientSize.Height - 120) / 2);
            size = Math.Max(100, size);

            picOriginal.Width = size;
            picOriginal.Height = size;

            foreach (var pb in processedPictureBoxes)
            {
                pb.Width = size;
                pb.Height = size;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        originalImage?.Dispose();
                        originalImage = new Bitmap(openFileDialog.FileName);
                        picOriginal.Image = originalImage;

                        ClearProcessedImages();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearProcessedImages()
        {
            foreach (var pb in processedPictureBoxes)
            {
                pb.Image?.Dispose();
                pb.Image = null;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please load an image first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnProcess.Enabled = false;
            btnLoad.Enabled = false;
            Cursor = Cursors.WaitCursor;
            ClearProcessedImages();

            cts?.Dispose();
            cts = new CancellationTokenSource();

            Task.Run(() => ProcessImages(cts.Token), cts.Token);
        }

        private void ProcessImages(CancellationToken token)
        {
            try
            {
                Bitmap[] sourceImages = new Bitmap[4];
                for (int i = 0; i < 4; i++)
                {
                    sourceImages[i] = new Bitmap(originalImage);
                }

                Parallel.For(0, 4, new ParallelOptions { CancellationToken = token }, i =>
                {
                    token.ThrowIfCancellationRequested();

                    using (Bitmap processedImage = new Bitmap(sourceImages[i]))
                    {
                        ApplyFilter(processedImage, i);

                        Bitmap displayImage = new Bitmap(processedImage);

                        this.Invoke((Action)(() =>
                        {
                            if (!token.IsCancellationRequested)
                            {
                                processedPictureBoxes[i].Image?.Dispose();
                                processedPictureBoxes[i].Image = displayImage;
                            }
                            else
                            {
                                displayImage.Dispose();
                            }
                        }));
                    }
                });

                foreach (var img in sourceImages)
                {
                    img.Dispose();
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                    MessageBox.Show($"Processing error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)));
            }
            finally
            {
                this.Invoke((Action)(() =>
                {
                    btnProcess.Enabled = true;
                    btnLoad.Enabled = true;
                    Cursor = Cursors.Default;
                }));
            }
        }

        private void ApplyFilter(Bitmap image, int filterIndex)
        {
            switch (filterIndex)
            {
                case 0: ApplyGrayscale(image); break;
                case 1: ApplyNegative(image); break;
                case 2: ApplyEdgeDetection(image); break;
                case 3: ApplyThreshold(image, 128); break;
            }
        }

        private void ApplyGrayscale(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    image.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
        }

        private void ApplyNegative(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    image.SetPixel(x, y, Color.FromArgb(
                        255 - pixel.R,
                        255 - pixel.G,
                        255 - pixel.B));
                }
            }
        }

        private void ApplyEdgeDetection(Bitmap image)
        {
            Bitmap tempImage = new Bitmap(image);

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    Color c1 = tempImage.GetPixel(x - 1, y - 1);
                    Color c2 = tempImage.GetPixel(x, y - 1);
                    Color c3 = tempImage.GetPixel(x + 1, y - 1);
                    Color c6 = tempImage.GetPixel(x - 1, y + 1);
                    Color c7 = tempImage.GetPixel(x, y + 1);
                    Color c8 = tempImage.GetPixel(x + 1, y + 1);

                    int gx = c1.R * -1 + c2.R * -2 + c3.R * -1 +
                             c6.R * 1 + c7.R * 2 + c8.R * 1;

                    int gy = c1.R * -1 + c3.R * 1 +
                             c6.R * -1 + c8.R * 1;

                    int magnitude = (int)Math.Sqrt(gx * gx + gy * gy);
                    magnitude = Math.Min(255, Math.Max(0, magnitude));

                    image.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }
            tempImage.Dispose();
        }

        private void ApplyThreshold(Bitmap image, int threshold)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    int newColor = gray > threshold ? 255 : 0;
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cts?.Cancel();
            cts?.Dispose();
            originalImage?.Dispose();
            ClearProcessedImages();
            base.OnFormClosing(e);
        }
    }
}