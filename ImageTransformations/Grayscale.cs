using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public class TfGrayscale : Lib.TransformationBase, Lib.ITransformable
    {

        public TfGrayscale() {
            Name = "Grayscale";
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