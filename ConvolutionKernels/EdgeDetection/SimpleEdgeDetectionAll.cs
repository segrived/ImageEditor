﻿namespace ImageEditor.ConvolutionKernels.EdgeDetection
{
    /// <summary>
    /// Фильтр свертки: Простое обнаружение границ по всем направлениям
    /// </summary>
    public class CkSimpleEdgeDetectionAll : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Simple Edge Detection (All Directions)";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CkSimpleEdgeDetectionAll()
        {
            Kernel = GetKernel();
            Factor = 1.0f;
            Offset = 0.0f;
        }

        private double[,] GetKernel()
        {
            return new double[,] {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
        }
    }
}
