using System;
using System.Drawing;
using ImageEditor.Lib;

namespace ImageEditor.ImageTransformations
{
    public class TfSepia : TransformationBase, ITransformable, IСonfigurable
    {
        [OptionAttribute(min: 1, max: 50, step: 1)]
        public int Depth { get; set; }

        public TfSepia(int depth)
        {
            this.Name = "Sepia";
            this.Depth = depth;
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            return Lib.ImageHelper.Transform(input, (p) => {
                var median = Lib.ImageHelper.Median(p);
                int red = Lib.ImageHelper.NormComp(median + Depth * 2);
                int green = Lib.ImageHelper.NormComp(median + Depth);
                int blue = median;
                return Color.FromArgb(red, green, blue);
            });
        }
    }
}
