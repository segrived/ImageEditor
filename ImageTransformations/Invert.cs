using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public class TfInvert : Lib.TransformationBase, Lib.ITransformable
    {
        public TfInvert()
        {
            Name = "Invert";
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            return Lib.ImageHelper.Transform(input, p => Color.FromArgb((byte)~p.R, (byte)~p.G, (byte)~p.B));
        }

    }
}