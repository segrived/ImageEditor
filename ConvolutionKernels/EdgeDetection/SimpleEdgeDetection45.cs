namespace ImageEditor.ConvolutionKernels.EdgeDetection
{
    /// <summary>
    /// Фильтр свертки: Простое обнаружение границ под углом 45 градусов
    /// </summary>
    public class CkSimpleEdgeDetection45 : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Simple Edge Detection (45°)";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CkSimpleEdgeDetection45()
        {
            Kernel = GetKernel();
            Factor = 1.0f;
            Offset = 0.0f;
        }

        private double[,] GetKernel()
        {
            return new double[,] {
                { -1,   0,  0,   0,   0 },
                {  0,  -2,  0,   0,   0 },
                {  0,   0,  6,   0,   0 },
                {  0,   0,  0,  -2,   0 },
                {  0,   0,  0,   0,  -1 }
            };
        }
    }
}
