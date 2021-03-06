﻿using System;

namespace ImageEditor.ConvolutionKernels.Blur
{
    /// <summary>
    /// Фильтр свертки: простое размытие
    /// </summary>
    public class CkSimpleBlur : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Simple Blur";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        private int BlurRadius { get; set; }

        public CkSimpleBlur(int radius)
        {
            // Радиус должен быть нечетным числом
            if (radius % 2 == 0) {
                throw new ArgumentException("Значение радиуса должно быть четным числом");
            }
            BlurRadius = radius;
            Kernel = GetKernel();
            Factor = 1.0f / (radius * radius / 2 + 1);
            Offset = 1.0f;
        }

        public double[,] GetKernel()
        {
            var kernel = new double[BlurRadius, BlurRadius];
            int center = BlurRadius / 2;
            for (int x = 0; x < BlurRadius; x++) {
                for (int y = 0; y < BlurRadius; y++) {
                    var c = Math.Abs(center - x);
                    if (c - 1 < y && y < BlurRadius - c)
                        kernel[x, y] = 1;
                }
            }
            return kernel;
        }
    }
}
