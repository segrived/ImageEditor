using System;
using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public class TF_Sepia : Lib.TransformationBase, Lib.ITransformable
    {
        public int Depth { get; set; }

        public TF_Sepia(int depth)
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
