using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageEditor.Lib
{
    /// <summary>
    /// Интерфейс должны наследовать все классы, изменяющие изображение
    /// </summary>
    public interface ITransformable
    {
        /// <summary>
        /// Название фильтра
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Функция, изменяющее изображение
        /// </summary>
        /// <param name="input">Исходное изображение</param>
        /// <returns>Измененное изображение</returns>
        Bitmap ApplyTransformation(Bitmap input);
    }

    /// <summary>
    /// Интерфейс должны наследовать все классы, у которых есть возможность
    /// сообщать текущий прогресс выполнения функции трансформации изображения
    /// </summary>
    public interface IProgressTracking
    {
        float Progress { get; set; }
        event EventHandler<ProgressEventArgs> ProgressChanged;
        event EventHandler<EventArgs> OperationComplete;
    }

    public interface IСonfigurable
    {
    }

    public class BitmapTransformation
    {
        private ITransformable Transformation { get; set; }

        public BitmapTransformation(ITransformable trans)
        {
            this.Transformation = trans;
        }

        public Bitmap Apply(Bitmap source)
        {
            return Transformation.ApplyTransformation(source);
        }
    }

}
