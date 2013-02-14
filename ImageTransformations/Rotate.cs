using System;
using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public enum RotateType
    {
        CLOCKWISE, COUNTERCLOCKWISE, A180
    }

    public class TF_Rotate : Lib.TransformationBase, Lib.ITransformable
    {
        private RotateType Rotate;

        public TF_Rotate(RotateType type)
        {
            this.Name = "Rotate";
            this.Rotate = type;
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            var width = input.Width;
            var height = input.Height;
            Bitmap newImage = (Rotate == RotateType.A180)
                ? new Bitmap(width, height)
                : new Bitmap(height, width);
            var InputProcessor = new Lib.FastBitmap(input);
            var OutputProcessor = new Lib.FastBitmap(newImage);
            InputProcessor.LockImage();
            OutputProcessor.LockImage();
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var old = InputProcessor.GetPixel(x, y);
                    switch (Rotate) {
                        case RotateType.CLOCKWISE:
                            OutputProcessor.SetPixel(height - y - 1, x, old); break;
                        case RotateType.COUNTERCLOCKWISE:
                            OutputProcessor.SetPixel(y, width - x - 1, old); break;
                        case RotateType.A180:
                            OutputProcessor.SetPixel(width - x - 1, height - y - 1, old); break;
                    }
                }
            }
            InputProcessor.UnlockImage();
            OutputProcessor.UnlockImage();
            return newImage;
        }
    }
}
