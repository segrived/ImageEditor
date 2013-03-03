namespace ImageEditor.ConvolutionKernels.Blur
{
    /// <summary>
    /// Фильтр свертки: размытие в движении
    /// </summary>
    public class CkMotionBlur : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Motion Blur";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        private int BlurRadius { get; set; }

        public CkMotionBlur(int radius)
        {
            BlurRadius = radius;
            Kernel = GetKernel();
            Factor = 1.0f / radius;
            Offset = 1.0f;
        }

        public double[,] GetKernel()
        {
            var kernel = new double[BlurRadius, BlurRadius];
            for (int x = 0; x < BlurRadius; x++) {
                for (int y = 0; y < BlurRadius; y++) {
                    kernel[x, y] = (x == y) ? 1.0 : 0.0;
                }
            }
            return kernel;
        }
    }
}
