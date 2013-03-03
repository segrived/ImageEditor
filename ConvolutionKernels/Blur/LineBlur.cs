namespace ImageEditor.ConvolutionKernels.Blur
{
    public class CkLineBlur : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Line Blur";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CkLineBlur()
        {
            Kernel = GetKernel();
            Factor = 1.0f / 3.0f;
            Offset = 1.0f;
        }

        public double[,] GetKernel()
        {
            return new double[,] {
                { 1, 1, 1 }
            };
        }
    }
}
