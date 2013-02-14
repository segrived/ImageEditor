using System;

namespace ImageEditor.ConvolutionKernels.Blur
{
    /// <summary>
    /// Фильтр свертки: "мягкое" размытие
    /// </summary>
    public class CK_SoftBlur : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Soft Blur";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        private int BlurRadius { get; set; }

        public CK_SoftBlur(int radius)
        {
            this.BlurRadius = radius;
            this.Kernel = GetMatrix();
            this.Factor = 1.0f;
            this.Offset = 1.0f;
        }

        public string GetName()
        {
            return Name;
        }

        private double[,] GetMatrix()
        {
            double[,] kernel = new double[BlurRadius, BlurRadius];
            int radius = BlurRadius / 2;
            double a = -2.0 * radius * radius / Math.Log(0.01);
            double sum = 0.0;
            for (int y = 0; y < kernel.GetLength(1); y++) {
                for (int x = 0; x < kernel.GetLength(0); x++) {
                    double dist = Math.Sqrt(
                        (x - radius) * (x - radius) +
                        (y - radius) * (y - radius)
                    );
                    kernel[x, y] = Math.Exp(-dist * dist / a);
                    sum += kernel[x, y];
                }
            }
            for (int y = 0; y < kernel.GetLength(1); y++) {
                for (int x = 0; x < kernel.GetLength(0); x++) {
                    kernel[x, y] /= sum;
                }
            }
            return kernel;
        }
    }
}
