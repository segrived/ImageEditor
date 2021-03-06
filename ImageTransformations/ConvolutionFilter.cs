﻿using System;
using System.Drawing;
using ImageEditor.Lib;

namespace ImageEditor.ImageTransformations
{

    public interface IConvolutionKernel
    {
        double[,] Kernel { get; set; }
        float Factor { get; set; }
        float Offset { get; set; }
        string Name { get; }
    }

    internal class TfConvolutionFilter : TransformationBase, ITransformable, IProgressTracking
    {
        /// <summary>
        /// Используемый фильтр свертки
        /// </summary>
        private readonly IConvolutionKernel _convKernel;

        public TfConvolutionFilter(IConvolutionKernel kernel)
        {
            Name = "CF: {0}".F(kernel.Name);
            _convKernel = kernel;
        }

        /// <summary>
        /// Перегружает имя эффекта, дабы в меню имена фильтров
        /// отображались без префикса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{0}".F(_convKernel.Name);
        }

        /// <summary>
        /// Применяет загруженное ядро к указанному изображению
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public Bitmap ApplyTransformation(Bitmap bitmap)
        {
            // Размер исходного изображения
            int imageWidth = bitmap.Width;
            int imageHeight = bitmap.Height;

            // Общее количество пикселей на изображение
            int fullImageSize = imageWidth * imageHeight;

            // Клонирование исходного изображения и создание нового для
            // резултатирующего изображения
            var inputImage = (Bitmap)bitmap.Clone();
            var newImage = new Bitmap(imageWidth, imageHeight);
            // Блокировка изображений (чтобы можно было работать напрямую
            // с изображениями в памяти)
            var inputProcessor = new FastBitmap(inputImage);
            var outputProcessor = new FastBitmap(newImage);
            inputProcessor.LockImage(); outputProcessor.LockImage();

            // Размер ядра свертки
            int filterWidth = _convKernel.Kernel.GetLength(0);
            int filterHeight = _convKernel.Kernel.GetLength(1);
            // Размер половины ядра свертки (для определния обрабатываемого пиксела)
            var fwd2 = filterWidth / 2;
            var fhd2 = filterHeight / 2;

            int previousProgress = 0;
            for (int x = 0; x < imageWidth; x++) {
                for (int y = 0; y < imageHeight; y++) {
                    // Инициализируем новые цветовые компоненты для
                    double cr = 0.0, cg = 0.0, cb = 0.0;
                    // Прогоняем все пикселы использую выбранный фильтр свертки
                    for (int fx = 0; fx < filterWidth; fx++) {
                        for (int fy = 0; fy < filterHeight; fy++) {
                            // Определение пиксела, к которому будет применяться
                            // текущее значение ядра
                            int ix = (x - fwd2 + fx + imageWidth) % imageWidth;
                            int iy = (y - fhd2 + fy + imageHeight) % imageHeight;

                            // Текущее значение ядра фильтра свертки
                            var cKernel = _convKernel.Kernel[fx, fy];

                            // Получать значение цвета каждого пиксела через структуру конечно
                            // удобно, но очень медленно. Поэтому забираю его как Int и
                            // вручную делю на компоненты сдвигами. Такие дела.
                            int rgb = inputProcessor.GetPixelInt(ix, iy);
                            cr += ((rgb >> 16) & 0xFF) * cKernel;
                            cg += ((rgb >> 8) & 0xFF) * cKernel;
                            cb += (rgb & 0xFF) * cKernel;
                        }
                    }
                    // Прогресс можно принимать значения от 1 до 100. Проверяем текущий прогресс
                    var currentProgress = (int)((x * imageHeight + y) / (float)fullImageSize * 100);
                    // Если он превышает значение предыдущего сохранённого - вызывается действие
                    if (currentProgress > previousProgress) {
                        OnProgressChanged(new ProgressEventArgs {
                            Progress = currentProgress
                        });
                        previousProgress = currentProgress;
                    }
                    // Устанавливается нового цвета для пиксела
                    var newColor = Color.FromArgb(
                        (byte)ImageHelper.NormComp((int)(_convKernel.Factor * cr + _convKernel.Offset)),
                        (byte)ImageHelper.NormComp((int)(_convKernel.Factor * cg + _convKernel.Offset)),
                        (byte)ImageHelper.NormComp((int)(_convKernel.Factor * cb + _convKernel.Offset))
                    );
                    outputProcessor.SetPixel(x, y, newColor);
                }
            }
            inputProcessor.UnlockImage();
            outputProcessor.UnlockImage();
            OnOperationComplete(EventArgs.Empty);
            return newImage;
        }
    }
}
