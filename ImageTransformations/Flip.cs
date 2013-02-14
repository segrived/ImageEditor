using System;
using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public enum FlipType { VERTICAL, HORIZONTAL }

    public class TF_Flip : Lib.TransformationBase, Lib.ITransformable
    {
        private FlipType Flip;

        public TF_Flip(FlipType type)
        {
            this.Name = "Flip";
            this.Flip = type;
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            var width = input.Width;
            var height = input.Height;
            return Lib.ImageHelper.FastPixel(input, (i, o) => {
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        var newPixel = (Flip == FlipType.HORIZONTAL)
                            ? i.GetPixel(width - x - 1, y)
                            : i.GetPixel(x, height - y - 1);
                        o.SetPixel(x, y, newPixel);
                    }
                }
            });
        }
    }
}
