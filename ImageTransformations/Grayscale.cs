using System;
using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public class TF_Grayscale : Lib.TransformationBase, Lib.ITransformable
    {

        public TF_Grayscale() {
            this.Name = "Greyscale";
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            return Lib.ImageHelper.Transform(input, p => {
                int median = Lib.ImageHelper.Median(p);
                return Color.FromArgb(median, median, median);
            });
        }

    }
}