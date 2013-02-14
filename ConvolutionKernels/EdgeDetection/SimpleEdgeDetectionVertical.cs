using System;

namespace ImageEditor.ConvolutionKernels.EdgeDetection
{
    /// <summary>
    /// Фильтр свертки: Простое обнаружение границ по вертикали
    /// </summary>
    public class CK_SimpleEdgeDetectionVertical : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Simple Edge Detection (Vertical)";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CK_SimpleEdgeDetectionVertical()
        {
            Kernel = GetKernel();
            Factor = 1.0f;
            Offset = 0.0f;
        }

        private double[,] GetKernel()
        {
            return new double[5, 5] {
                { 0,  0,  -1,  0,  0 },
                { 0,  0,  -1,  0,  0 },
                { 0,  0,   4,  0,  0 },
                { 0,  0,  -1,  0,  0 },
                { 0,  0,  -1,  0,  0 }
            };
        }
    }
}
