namespace parallel_image_processing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMain = new Panel();
            tableProcessed = new TableLayoutPanel();
            picProcessed1 = new PictureBox();
            picProcessed2 = new PictureBox();
            picProcessed3 = new PictureBox();
            picProcessed4 = new PictureBox();
            picOriginal = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnLoad = new Button();
            btnProcess = new Button();
            panelMain.SuspendLayout();
            tableProcessed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProcessed1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.Controls.Add(tableProcessed);
            panelMain.Controls.Add(picOriginal);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(40, 40);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(898, 664);
            panelMain.TabIndex = 4;
            // 
            // tableProcessed
            // 
            tableProcessed.AutoSize = true;
            tableProcessed.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableProcessed.ColumnCount = 2;
            tableProcessed.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableProcessed.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableProcessed.Controls.Add(picProcessed1, 0, 0);
            tableProcessed.Controls.Add(picProcessed2, 1, 0);
            tableProcessed.Controls.Add(picProcessed3, 0, 1);
            tableProcessed.Controls.Add(picProcessed4, 1, 1);
            tableProcessed.Dock = DockStyle.Right;
            tableProcessed.Location = new Point(302, 0);
            tableProcessed.Name = "tableProcessed";
            tableProcessed.RowCount = 2;
            tableProcessed.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableProcessed.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableProcessed.Size = new Size(596, 664);
            tableProcessed.TabIndex = 1;
            // 
            // picProcessed1
            // 
            picProcessed1.Dock = DockStyle.Fill;
            picProcessed1.Location = new Point(3, 3);
            picProcessed1.Name = "picProcessed1";
            picProcessed1.Size = new Size(292, 326);
            picProcessed1.SizeMode = PictureBoxSizeMode.Zoom;
            picProcessed1.TabIndex = 0;
            picProcessed1.TabStop = false;
            // 
            // picProcessed2
            // 
            picProcessed2.Dock = DockStyle.Fill;
            picProcessed2.Location = new Point(301, 3);
            picProcessed2.Name = "picProcessed2";
            picProcessed2.Size = new Size(292, 326);
            picProcessed2.SizeMode = PictureBoxSizeMode.Zoom;
            picProcessed2.TabIndex = 1;
            picProcessed2.TabStop = false;
            // 
            // picProcessed3
            // 
            picProcessed3.Dock = DockStyle.Fill;
            picProcessed3.Location = new Point(3, 335);
            picProcessed3.Name = "picProcessed3";
            picProcessed3.Size = new Size(292, 326);
            picProcessed3.SizeMode = PictureBoxSizeMode.Zoom;
            picProcessed3.TabIndex = 2;
            picProcessed3.TabStop = false;
            // 
            // picProcessed4
            // 
            picProcessed4.Dock = DockStyle.Fill;
            picProcessed4.Location = new Point(301, 335);
            picProcessed4.Name = "picProcessed4";
            picProcessed4.Size = new Size(292, 326);
            picProcessed4.SizeMode = PictureBoxSizeMode.Zoom;
            picProcessed4.TabIndex = 3;
            picProcessed4.TabStop = false;
            // 
            // picOriginal
            // 
            picOriginal.Dock = DockStyle.Left;
            picOriginal.Location = new Point(0, 0);
            picOriginal.Name = "picOriginal";
            picOriginal.Size = new Size(300, 664);
            picOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            picOriginal.TabIndex = 0;
            picOriginal.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnLoad, 0, 0);
            tableLayoutPanel1.Controls.Add(btnProcess, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(40, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(898, 50);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // btnLoad
            // 
            btnLoad.AutoSize = true;
            btnLoad.Dock = DockStyle.Fill;
            btnLoad.Location = new Point(3, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(443, 44);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnProcess
            // 
            btnProcess.Dock = DockStyle.Fill;
            btnProcess.Location = new Point(452, 3);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(443, 44);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 744);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelMain);
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            Padding = new Padding(40);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Processor";
            WindowState = FormWindowState.Maximized;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            tableProcessed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picProcessed1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed4).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMain;
        private TableLayoutPanel tableProcessed;
        private PictureBox picOriginal;
        private PictureBox picProcessed1;
        private PictureBox picProcessed2;
        private PictureBox picProcessed3;
        private PictureBox picProcessed4;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnLoad;
        private Button btnProcess;
    }
}