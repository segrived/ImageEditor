using System.Drawing;

namespace ImageEditor.ImageTransformations
{
    public enum RotateType
    {
        Clockwise, Counterclockwise, A180
    }

    public class TfRotate : Lib.TransformationBase, Lib.ITransformable
    {
        private readonly RotateType _rotate;

        public TfRotate(RotateType type)
        {
            Name = "Rotate";
            _rotate = type;
        }

        public Bitmap ApplyTransformation(Bitmap input)
        {
            var width = input.Width;
            var height = input.Height;
            Bitmap newImage = (_rotate == RotateType.A180)
                ? new Bitmap(width, height)
                : new Bitmap(height, width);
            var inputProcessor = new Lib.FastBitmap(input);
            var outputProcessor = new Lib.FastBitmap(newImage);
            inputProcessor.LockImage();
            outputProcessor.LockImage();
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var old = inputProcessor.GetPixel(x, y);
                    switch (_rotate) {
                        case RotateType.Clockwise:
                            outputProcessor.SetPixel(height - y - 1, x, old); break;
                        case RotateType.Counterclockwise:
                            outputProcessor.SetPixel(y, width - x - 1, old); break;
                        case RotateType.A180:
                            outputProcessor.SetPixel(width - x - 1, height - y - 1, old); break;
                    }
                }
            }
            inputProcessor.UnlockImage();
            outputProcessor.UnlockImage();
            return newImage;
        }
    }
}
