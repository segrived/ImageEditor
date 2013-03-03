using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public enum FlipType { Vertical, Horizontal }

    public class TfFlip : Lib.TransformationBase, Lib.ITransformable
    {
        private readonly FlipType _flip;

        public TfFlip(FlipType type)
        {
            Name = "Flip";
            _flip = type;
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            var width = input.Width;
            var height = input.Height;
            return Lib.ImageHelper.FastPixel(input, (i, o) => {
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        var newPixel = (_flip == FlipType.Horizontal)
                            ? i.GetPixel(width - x - 1, y)
                            : i.GetPixel(x, height - y - 1);
                        o.SetPixel(x, y, newPixel);
                    }
                }
            });
        }
    }
}
