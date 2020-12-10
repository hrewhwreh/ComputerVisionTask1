using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using Accord.Imaging;
using AForge.Imaging;
using Accord.Imaging.Filters;

namespace ComputerVision1
{
    abstract class Filters
    {
        public abstract Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker);

        public int Clamp (int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }

    class GrayScale : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap resultImage = filter.Apply(sourceImage);
            worker.ReportProgress(100);
            return resultImage;
        }
    }

    class UpgradeContrast : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            ContrastStretch filter1 = new ContrastStretch();
            Bitmap resultImage = filter1.Apply(sourceImage);
            worker.ReportProgress(50);
            HistogramEqualization filter2 = new HistogramEqualization();
            resultImage = filter2.Apply(resultImage);
            worker.ReportProgress(100);
            return filter2.Apply(resultImage);
        }
    }

    class Canny : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            CannyEdgeDetector filter = new CannyEdgeDetector((int)(255 * 0.1), (int)(255 * 0.2));
            Bitmap resultImage = filter.Apply(sourceImage);
            worker.ReportProgress(100);
            return resultImage;
        }
    }

    class Harris : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            HarrisCornersDetector hcd = new HarrisCornersDetector(0.05f, 20000);
            Bitmap resultImage = sourceImage;
            List<Accord.IntPoint> corners = hcd.ProcessImage(sourceImage);
            worker.ReportProgress(50);
            resultImage = resultImage.Clone(PixelFormat.Format24bppRgb);
            worker.ReportProgress(75);
            while (corners.Count != 0)
            {
                Accord.IntPoint a = corners[corners.Count - 1];
                resultImage = drawEllipse(resultImage, a.X, a.Y);
                corners.RemoveAt(corners.Count - 1);
            }
            worker.ReportProgress(100);
            return resultImage;
        }
        public Bitmap drawEllipse(Bitmap sourceImage, int x, int y)
        {
            Bitmap resultImage = sourceImage;
            resultImage.SetPixel(Clamp(x - 2, 0, resultImage.Width - 1), Clamp(y, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            resultImage.SetPixel(Clamp(x - 1, 0, resultImage.Width - 1), Clamp(y + 1, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            resultImage.SetPixel(Clamp(x, 0, resultImage.Width - 1), Clamp(y + 2, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            resultImage.SetPixel(Clamp(x + 1, 0, resultImage.Width - 1), Clamp(y + 1, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            resultImage.SetPixel(Clamp(x + 2, 0, resultImage.Width - 1), Clamp(y, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            resultImage.SetPixel(Clamp(x + 1, 0, resultImage.Width - 1), Clamp(y - 1, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            resultImage.SetPixel(Clamp(x, 0, resultImage.Width - 1), Clamp(y - 2, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            resultImage.SetPixel(Clamp(x - 1, 0, resultImage.Width - 1), Clamp(y - 1, 0, resultImage.Height - 1), Color.FromArgb(255, 0, 0));
            return resultImage;
        }
    }
    
    class TransformDistance : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            DistanceTransform dt = new DistanceTransform(DistanceTransformMethod.Euclidean);
            Bitmap resultImage = dt.Apply(sourceImage);
            worker.ReportProgress(100);
            return resultImage;
        }
    }

    class MeanFilter : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap tempImage1 = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap tempImage2 = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap tempImage3 = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color tmp = sourceImage.GetPixel(i, j);
                    tempImage1.SetPixel(i, j, Color.FromArgb(tmp.R, 0, 0));
                    tempImage2.SetPixel(i, j, Color.FromArgb(0, tmp.G, 0));
                    tempImage3.SetPixel(i, j, Color.FromArgb(0, 0, tmp.B));
                }
            }
            IntegralImage2 imageIntegral1 = IntegralImage2.FromBitmap(sourceImage);
            IntegralImage2 imageIntegral2 = IntegralImage2.FromBitmap(sourceImage, 1);
            IntegralImage2 imageIntegral3 = IntegralImage2.FromBitmap(sourceImage, 2);
            worker.ReportProgress(50);
            int radius = 2;
            long meanCoef1, meanCoef2, meanCoef3;
            for (int i = 1; i <= sourceImage.Width; i++)
            {
                for (int j = 1; j <= sourceImage.Height; j++)
                {
                    meanCoef1 = imageIntegral1.GetSum(Clamp(i - radius, 0, sourceImage.Width), Clamp(j - radius, 0, sourceImage.Height),
                        Clamp(2 * radius + 1, 0, sourceImage.Width - i),
                        Clamp(2 * radius + 1, 0, sourceImage.Height - j)) / ((2 * radius + 1) * (2 * radius + 1));

                    meanCoef2 = imageIntegral2.GetSum(Clamp(i - radius, 0, sourceImage.Width), Clamp(j - radius, 0, sourceImage.Height),
                        Clamp(2 * radius + 1, 0, sourceImage.Width - i),
                        Clamp(2 * radius + 1, 0, sourceImage.Height - j)) / ((2 * radius + 1) * (2 * radius + 1));

                    meanCoef3 = imageIntegral3.GetSum(Clamp(i - radius, 0, sourceImage.Width), Clamp(j - radius, 0, sourceImage.Height),
                        Clamp(2 * radius + 1, 0, sourceImage.Width - i),
                        Clamp(2 * radius + 1, 0, sourceImage.Height - j)) / ((2 * radius + 1) * (2 * radius + 1));
                    Color resultColor = Color.FromArgb(Clamp((int)meanCoef3, 0, 255), Clamp((int)meanCoef2, 0, 255), Clamp((int)meanCoef1, 0, 255));
                    resultImage.SetPixel(i - 1, j - 1, resultColor);
                }
            }
            return resultImage;
        }
    }
}
