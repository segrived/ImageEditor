using System;

namespace ImageEditor.ConvolutionKernels.Sharpen
{
    /// <summary>
    /// Фильтр свертки: простое увеличений резкости
    /// </summary>
    public class CK_SimpleSharpen : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Simple Sharpen";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CK_SimpleSharpen()
        {
            Kernel = GetKernel();
            Factor = 1.0f;
            Offset = 0.0f;
        }

        private double[,] GetKernel()
        {
            return new double[3, 3] {
                { -1, -1, -1 },
                { -1,  9, -1 },
                { -1, -1, -1 }
            };
        }
    }
}
