using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Lib
{
    /// <summary>
    /// Дополнительные функции для обработки изображений
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Нормализирует компоненту цвета
        /// </summary>
        /// <param name="comp">Значение компоненты</param>
        public static int NormComp(int comp)
        {
            int res = comp;
            if (comp < 0) res = 0;
            if (comp > 255) res = 255;
            return res;
        }

        /// <summary>
        /// Возвращает усереднённую компоненту цвета
        /// </summary>
        /// <param name="rgb">Набор цветов в плоскости RGB</param>
        /// <returns></returns>
        public static int Median(Color rgb)
        {
            return (int)((rgb.R + rgb.G + rgb.B) / 3);
        }

        /// <summary>
        /// Применяет функцию, переданную параметром pixelTransform к каждому пикселу
        /// </summary>
        /// <param name="InputBitmap"></param>
        /// <param name="pixelTransform"></param>
        /// <returns></returns>
        public static Bitmap Transform(Bitmap InputBitmap, Func<Color, Color> pixelTransform)
        {
            var width = InputBitmap.Width;
            var height = InputBitmap.Height;
            return FastPixel(InputBitmap, (i, o) => {
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        var newPixel = pixelTransform(i.GetPixel(x, y));
                        o.SetPixel(x, y, newPixel);
                    }
                }
            });
        }

        public static Bitmap TransformX(Bitmap InputBitmap, Func<int, int, Color> pixelTransform)
        {
            var width = InputBitmap.Width;
            var height = InputBitmap.Height;
            return FastPixel(InputBitmap, (i, o) => {
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        var newPixel = pixelTransform(x, y);
                        o.SetPixel(x, y, newPixel);
                    }
                }
            });
        }

        public static Bitmap FastPixel(Bitmap InputBitmap, Action<FastBitmap, FastBitmap> processors)
        {
            Bitmap newImage = new Bitmap(InputBitmap.Width, InputBitmap.Height);
            var InputProcessor = new FastBitmap(InputBitmap);
            var OutputProcessor = new FastBitmap(newImage);
            InputProcessor.LockImage();
            OutputProcessor.LockImage();
            processors(InputProcessor, OutputProcessor);
            InputProcessor.UnlockImage();
            OutputProcessor.UnlockImage();
            return newImage;
        }

    }
}
