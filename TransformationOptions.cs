using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class TransformationOptions : Form
    {
        public Bitmap PreviewBitmap;

        public TransformationOptions()
        {
            InitializeComponent();
        }

        private void TransformationOptions_Load(object sender, EventArgs e)
        {
            if(PreviewBitmap != null)
                this.PreviewBox.Image = PreviewBitmap;
        }

        public void SyncImage()
        {
            PreviewBox.Image = PreviewBitmap;
            PreviewBox.Update();
        }
    }
}
