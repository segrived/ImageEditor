﻿using System;

namespace ImageEditor.ConvolutionKernels.EdgeDetection
{
    /// <summary>
    /// Фильтр свертки: Простое обнаружение границ по горизонтали
    /// </summary>
    public class CK_SimpleEdgeDetectionHorizontal : ImageTransformations.IConvolutionKernel
    {
        public const string _name = "Simple Edge Detection (Horizontal)";
        public string Name { get { return _name; } }

        public double[,] Kernel { get; set; }
        public float Factor { get; set; }
        public float Offset { get; set; }

        public CK_SimpleEdgeDetectionHorizontal()
        {
            Kernel = GetKernel();
            Factor = 1.0f;
            Offset = 0.0f;
        }

        private double[,] GetKernel()
        {
            return new double[5, 5]  {
                {  0,   0,  0,  0,  0 },
                {  0,   0,  0,  0,  0 },
                { -1,  -1,  2,  0,  0 },
                {  0,   0,  0,  0,  0 },
                {  0,   0,  0,  0,  0 }
            };
        }
    }
}
