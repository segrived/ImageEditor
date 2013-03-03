using System;

namespace ImageEditor.Lib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false) ]
    public class OptionAttribute : Attribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Step { get; set; }

        public OptionAttribute(int min, int max, int step)
        {
            this.Min = min;
            this.Max = max;
            this.Step = step;
        }
    }
}
