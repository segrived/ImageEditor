using System;
using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public class TF_Invert : Lib.TransformationBase, Lib.ITransformable
    {
        public TF_Invert()
        {
            this.Name = "Invert";
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            return Lib.ImageHelper.Transform(input, p => {
                return Color.FromArgb((byte)~p.R, (byte)~p.G, (byte)~p.B);
            });
        }

    }
}