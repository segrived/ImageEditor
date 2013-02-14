using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ImageEditor.Lib;
using ImageEditor.ImageTransformations;
using System.IO;

namespace ImageEditor
{
    public partial class MainForm : Form
    {
        private string LoadedFileName;
        private Bitmap WorkingBitmap;
        private ImageFormat WorkingBitmapFormat;
        private History<Bitmap> History;

        public MainForm()
        {
            InitializeComponent();
            InitializeFilters();
            History = new History<Bitmap>(10);
            UpdateMenuHistoryItems();
        }


        private void InitializeFilters()
        {

            // Фильтры свертки
            List<TF_ConvolutionFilter> covnFilters = new List<IConvolutionKernel> {
                // Sharpen-фильтры (увеличение резкости)
                new ConvolutionKernels.Sharpen.CK_SimpleSharpen(),
                new ConvolutionKernels.Sharpen.CK_SoftSharpen(),
                new ConvolutionKernels.Sharpen.CK_EdgeSharpen(),
                // Blur-фильтры (размытие)
                new ConvolutionKernels.Blur.CK_SimpleBlur(radius: 5),
                new ConvolutionKernels.Blur.CK_SoftBlur(radius: 5),
                new ConvolutionKernels.Blur.CK_MotionBlur(radius: 9),
                // Edge Detection-фильтры (обнаружение границ)
                new ConvolutionKernels.EdgeDetection.CK_SimpleEdgeDetectionAll(),
                new ConvolutionKernels.EdgeDetection.CK_SimpleEdgeDetectionHorizontal(),
                new ConvolutionKernels.EdgeDetection.CK_SimpleEdgeDetectionVertical(),
                new ConvolutionKernels.EdgeDetection.CK_SimpleEdgeDetection45(),
                // Emboss-фильтры (эффект тиснения)
                new ConvolutionKernels.Emboss.CK_SimpleEmboss()
            }.ConvertAll(k => new TF_ConvolutionFilter(k));

            // Эффекты (цветокоррекция)
            List<ITransformable> effects = new List<ITransformable> {
                new TF_Grayscale(), new TF_Invert(), new TF_Sepia(20)
            };

            foreach (var effect in effects) {
                ToolStripMenuItem item = new ToolStripMenuItem(effect.ToString());
                item.Click += (sender, e) => {
                    ApplyBitmapTransformation(effect);
                };
                MenuAdjustments.DropDownItems.Add(item);
            }

            // Добавление фильтров в меню
            foreach (var filter in covnFilters) {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(filter.ToString());
                menuItem.Click += (sender, e) => {
                    ApplyBitmapTransformation(filter);
                };
                MenuEffects.DropDownItems.Add(menuItem);
            }
        }

        private async void ApplyBitmapTransformation(ITransformable transformation)
        {
            BitmapTransformation f = new BitmapTransformation(transformation);
            if (transformation is IProgressTracking) {
                var progressBarForm = new ProgressForm();
                progressBarForm.Text = "Идёт применение фильтра: {0} (0%)".F(transformation.ToString());
                progressBarForm.Show();
                IProgressTracking trackingObj = transformation as IProgressTracking;
                trackingObj.ProgressChanged += (s, p) => {
                    this.BeginInvoke((MethodInvoker)delegate {
                        progressBarForm.Progress.Value = p.Progress;
                        progressBarForm.Text = "Идёт применение фильтра: {0} ({1}%)"
                            .F(transformation.ToString(), p.Progress);
                    });
                };
                trackingObj.OperationComplete += (s, p) => {
                    this.BeginInvoke((MethodInvoker)delegate {
                        progressBarForm.Close();
                    });
                };
            }
            WorkingBitmap = await Task<Bitmap>.Factory.StartNew(() => {
                return f.Apply(WorkingBitmap);
            });
            History.SaveState(WorkingBitmap);
            UpdateMenuHistoryItems();
            SyncPicture();
        }


        /// <summary>
        /// Отображает диалог открытия файла и открывает выбранный файл
        /// </summary>
        private void LoadImage(string FileName)
        {
            try {
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(FileName));
                Bitmap bitmap = (Bitmap)Image.FromStream(ms);
                this.WorkingBitmap = bitmap;
                this.WorkingBitmapFormat = bitmap.GetImageFormat();
                this.LoadedFileName = FileName;
                // Сохранем состояние исходного изображения
                History.SaveState(WorkingBitmap);
                // Обновляем изображение в PictureBox
                SyncPicture();
            } catch (Exception ex) {
                var msg = "При открытии файла произошла ошибка: {0}";
                MessageBox.Show(msg.F(ex.Message), "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveImage(string fileName, ImageFormat format)
        {
            try {
                WorkingBitmap.Save(fileName, format);
            } catch (Exception ex) {
                var msg = "При сохранении файла произошла ошибка: {0}";
                MessageBox.Show(msg.F(ex.Message), "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Синхронизирует изображение на форме с рабочим изображением
        /// </summary>
        public void SyncPicture()
        {
            if (WorkingBitmap != null) {
                PictureLoaded.Image = WorkingBitmap;
            }
        }

        private void UpdateMenuHistoryItems()
        {
            MenuEditUndo.Enabled = History.CanUndo();
            MenuEditRedo.Enabled = History.CanRedo();
        }

        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;
            LoadImage(dialog.FileName);
            // TODO: вынести отдельно
            MenuEffects.Enabled = true;
            MenuAdjustments.Enabled = true;
            MenuImage.Enabled = true;
            MenuFileSave.Enabled = true;
            MenuFileSaveAs.Enabled = true;
        }

        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            WorkingBitmap.Save(LoadedFileName, WorkingBitmapFormat);
        }

        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (WorkingBitmap == null) return;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            dialog.Title = "Save an Image File";
            if (dialog.ShowDialog() != DialogResult.OK || dialog.FileName.Equals("")) return;
            // Дефолт
            ImageFormat format = ImageFormat.Bmp;
            switch (dialog.FilterIndex) {
                case 1: format = ImageFormat.Jpeg; break;
                case 2: format = ImageFormat.Bmp; break;
                case 3: format = ImageFormat.Gif; break;
                case 4: format = ImageFormat.Png; break;
            }
            dialog.Dispose();
            SaveImage(dialog.FileName, format);
        }

        private void MenuEditUndo_Click(object sender, EventArgs e)
        {
            if (! History.CanUndo()) return;
            WorkingBitmap = History.Undo();
            UpdateMenuHistoryItems();
            SyncPicture();
        }

        private void MenuEditRedo_Click(object sender, EventArgs e)
        {
            if (!History.CanRedo()) return;
            WorkingBitmap = History.Redo();
            UpdateMenuHistoryItems();
            SyncPicture();
        }

        private void MenuImageRotate180_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TF_Rotate(RotateType.A180));
        }

        private void MneuImageFlipHorizontal_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TF_Flip(FlipType.HORIZONTAL));
        }

        private void MenuImageFlipVertical_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TF_Flip(FlipType.VERTICAL));
        }

        private void MenuImageRotate90Clockwise_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TF_Rotate(RotateType.CLOCKWISE));
        }

        private void MenuImageRotate90CounterClockwise_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TF_Rotate(RotateType.COUNTERCLOCKWISE));
        }

        private void MenuEditPreferences_Click(object sender, EventArgs e)
        {
            PreferencesForm pref = new PreferencesForm();
            pref.ShowDialog();
            pref.Dispose();
        }

        private void MenuViewSizeModeDefault_Click(object sender, EventArgs e)
        {
            this.PictureLoaded.Dock = DockStyle.None;
            this.PictureLoaded.SizeMode = PictureBoxSizeMode.AutoSize;
            this.MenuViewSizeModeDefault.CheckState = CheckState.Checked;
            this.MenuViewSizeModeStretch.CheckState = CheckState.Unchecked;
            this.MenuViewSizeModeZoom.CheckState = CheckState.Unchecked;
        }

        private void MenuViewSizeModeStretch_Click(object sender, EventArgs e)
        {
            this.PictureLoaded.Dock = DockStyle.Fill;
            this.PictureLoaded.SizeMode = PictureBoxSizeMode.StretchImage;
            this.MenuViewSizeModeStretch.CheckState = CheckState.Checked;
            this.MenuViewSizeModeDefault.CheckState = CheckState.Unchecked;
            this.MenuViewSizeModeZoom.CheckState = CheckState.Unchecked;
        }

        private void MenuViewSizeModeZoom_Click(object sender, EventArgs e)
        {
            this.PictureLoaded.Dock = DockStyle.Fill;
            this.PictureLoaded.SizeMode = PictureBoxSizeMode.Zoom;
            this.MenuViewSizeModeZoom.CheckState = CheckState.Checked;
            this.MenuViewSizeModeStretch.CheckState = CheckState.Unchecked;
            this.MenuViewSizeModeDefault.CheckState = CheckState.Unchecked;
        }


    }
}
