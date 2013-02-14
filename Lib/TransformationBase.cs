using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Lib
{


    public class ProgressEventArgs : EventArgs
    {
        public int Progress { get; set; }
    }

    public class TransformationBase
    {
        /// <summary>
        /// Прогресс обработки изображения
        /// </summary>
        public float Progress { get; set; }
        /// <summary>
        /// Действие, вызываемое при изменении прогресса
        /// </summary>
        public event EventHandler<ProgressEventArgs> ProgressChanged;
        /// <summary>
        /// Действие, вызываемое при завершении операции
        /// </summary>
        public event EventHandler<EventArgs> OperationComplete;

        public string Name { get; protected set; }

        public override string ToString()
        {
            return Name;
        }

        protected virtual void OnProgressChanged(ProgressEventArgs e)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, e);
        }

        protected virtual void OnOperationComplete(EventArgs e)
        {
            if (OperationComplete != null)
                OperationComplete(this, e);
        }
    }
}
