namespace ImageEditor.ConvolutionKernels.Emboss
{
    /// <summary>
    /// Фильтр свертки: эффект тиснения
    /// </summary>
    public class CkSimpleEmboss : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Simple Emboss";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CkSimpleEmboss()
        {
            Kernel = GetKernel();
            Factor = 1.0f;
            Offset = 128.0f;
        }

        private double[,] GetKernel()
        {
            return new double[,] {
                { -1, -1, 5, -1, -1 }
            };
        }
    }
}
