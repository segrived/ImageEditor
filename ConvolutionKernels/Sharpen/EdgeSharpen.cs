namespace ImageEditor.ConvolutionKernels.Sharpen
{
    /// <summary>
    /// Фильтр свертки: увеличений резкости с упором на границы изображения
    /// </summary>
    public class CkEdgeSharpen : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Edge Sharpen";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CkEdgeSharpen()
        {
            Kernel = GetKernel();
            Factor = 1.0f;
            Offset = 0.0f;
        }

        private double[,] GetKernel()
        {
            return new double[,] {
                {1,  1, 1},
                {1, -7, 1},
                {1,  1, 1}
            };
        }
    }
}
