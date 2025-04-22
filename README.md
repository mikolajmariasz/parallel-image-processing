# Parallel Image Processing App

## Project Description

A Windows Forms application for parallel image processing using multi-threading. The program allows loading an image and applying four different filters simultaneously using parallel processing techniques.

## Key Features

- **Image Loading** (JPG, PNG, BMP formats)
- **Four Image Filters**:
  - Grayscale conversion
  - Negative
  - Edge detection
  - Thresholding (binarization)
- **Parallel Processing** using `Parallel.For`

## Multi-threading Implementation

The core multi-threading implementation:

```csharp
Parallel.For(0, 4, new ParallelOptions { CancellationToken = token }, i =>
{
    // Each filter runs in separate thread
    using (Bitmap processedImage = new Bitmap(sourceImages[i]))
    {
        ApplyFilter(processedImage, i);
        // ... image processing
    }
});
```
Each filter runs in a separate thread, significantly improving performance for large images. The system automatically manages thread pooling.

<img width="1120" alt="image" src="https://github.com/user-attachments/assets/dcbf4370-44ed-4cdf-b1b2-066206f8c051" />
