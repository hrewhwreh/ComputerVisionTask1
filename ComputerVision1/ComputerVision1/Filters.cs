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
            IntegralImage2 imageIntegral = IntegralImage2.FromBitmap(sourceImage.Clone(PixelFormat.Format24bppRgb));
            long[,] sumTable = imageIntegral.Image;
            worker.ReportProgress(50);
            int deepDistTranform = 255;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int tmp = sourceImage.GetPixel(i, j).R;
                    if (tmp > 0 && tmp < deepDistTranform)
                    {
                        deepDistTranform = tmp;
                    }
                }
            }
            deepDistTranform = 255 / deepDistTranform;
            worker.ReportProgress(75);
            int intensity;
            int radius;
            long meanCoef;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    intensity = sourceImage.GetPixel(i, j).R;
                    radius = 5 * deepDistTranform * intensity / 255;
                    if (radius != 0)
                    {
                        if (i + 1 + radius > sourceImage.Width - 1 && j + 1 + radius > sourceImage.Height - 1)
                        {
                            meanCoef = imageIntegral.GetSum(Clamp(i + 1 - radius, 0, sourceImage.Width), Clamp(j + 1 - radius, 0, sourceImage.Height),
                                Clamp(2 * radius + 1, 0, -sourceImage.Width + i + 1 + radius),
                                Clamp(2 * radius + 1, 0, -sourceImage.Height + j + 1 + radius)) / (radius * radius);
                        } 
                        else if (i + 1 + radius > sourceImage.Width - 1)
                        {
                            meanCoef = imageIntegral.GetSum(Clamp(i + 1 - radius, 0, sourceImage.Width), Clamp(j + 1 - radius, 0, sourceImage.Height),
                                Clamp(2 * radius + 1, 0, -sourceImage.Width + i + 1 + radius), 2 * radius + 1) / (radius * radius);
                        }
                        else if (j + 1 + radius > sourceImage.Height - 1)
                        {
                            meanCoef = imageIntegral.GetSum(Clamp(i + 1 - radius, 0, sourceImage.Width), Clamp(j + 1 - radius, 0, sourceImage.Height),
                                2 * radius + 1, Clamp(2 * radius + 1, 0, -sourceImage.Height + j + 1 + radius)) / (radius * radius);
                        }
                        else
                        {
                            meanCoef = imageIntegral.GetSum(Clamp(i + 1 - radius, 0, sourceImage.Width), Clamp(j + 1 - radius, 0, sourceImage.Height),
                                2 * radius + 1, 2 * radius + 1) / (radius * radius);
                        }
                        Color resultColor = Color.FromArgb(Clamp((int)meanCoef, 0, 255), Clamp((int)meanCoef, 0, 255), Clamp((int)meanCoef, 0, 255));
                        resultImage.SetPixel(i, j, resultColor);
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, sourceImage.GetPixel(i, j));
                    }
                }
            }
            return resultImage;
        }
    }
}
