using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.ConvolutionKernels.Sharpen
{
    /// <summary>
    /// Фильтр свертки: "мягкое" увеличений резкости
    /// </summary>
    public class CK_SoftSharpen : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Soft Sharpen";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CK_SoftSharpen()
        {
            Kernel = GetKernel();
            Factor = 1.0f / 8.0f;
            Offset = 0.0f;
        }

        private double[,] GetKernel()
        {
            return new double[5, 5] {
                {-1, -1, -1, -1, -1},
                {-1,  2,  2,  2, -1},
                {-1,  2,  8,  2, -1},
                {-1,  2,  2,  2, -1},
                {-1, -1, -1, -1, -1}
            };
        }
    }
}
