using System;
using System.Collections.Generic;
using System.Drawing;
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
        private string _loadedFileName;
        private Bitmap _workingBitmap;
        private ImageFormat _workingBitmapFormat;
        private readonly History<Bitmap> _history;

        public MainForm()
        {
            InitializeComponent();
            InitializeFilters();
            _history = new History<Bitmap>(10);
            UpdateMenuHistoryItems();
        }


        private void InitializeFilters()
        {

            // Фильтры свертки
            var covnFilters = new List<IConvolutionKernel> {
                // Sharpen-фильтры (увеличение резкости)
                new ConvolutionKernels.Sharpen.CkSimpleSharpen(),
                new ConvolutionKernels.Sharpen.CkSoftSharpen(),
                new ConvolutionKernels.Sharpen.CkEdgeSharpen(),
                // Blur-фильтры (размытие)
                new ConvolutionKernels.Blur.CkSimpleBlur(radius: 5),
                new ConvolutionKernels.Blur.CkSoftBlur(radius: 5),
                new ConvolutionKernels.Blur.CkMotionBlur(radius: 9),
                new ConvolutionKernels.Blur.CkLineBlur(),
                // Edge Detection-фильтры (обнаружение границ)
                new ConvolutionKernels.EdgeDetection.CkSimpleEdgeDetectionAll(),
                new ConvolutionKernels.EdgeDetection.CkSimpleEdgeDetectionHorizontal(),
                new ConvolutionKernels.EdgeDetection.CkSimpleEdgeDetectionVertical(),
                new ConvolutionKernels.EdgeDetection.CkSimpleEdgeDetection45(),
                // Emboss-фильтры (эффект тиснения)
                new ConvolutionKernels.Emboss.CkSimpleEmboss()
            }.ConvertAll(k => new TfConvolutionFilter(k));

            // Эффекты (цветокоррекция)
            var effects = new List<ITransformable> {
                new TfGrayscale(), new TfInvert(), new TfSepia(20)
            };

            foreach (var effect in effects) {
                var item = new ToolStripMenuItem(effect.ToString());
                var eff = effect;
                item.Click += (sender, e) => ApplyBitmapTransformation(eff);
                MenuAdjustments.DropDownItems.Add(item);
            }

            // Добавление фильтров в меню
            foreach (var filter in covnFilters) {
                var menuItem = new ToolStripMenuItem(filter.ToString());
                var f = filter;
                menuItem.Click += (sender, e) => ApplyBitmapTransformation(f);
                MenuEffects.DropDownItems.Add(menuItem);
            }
        }

        private async void ApplyBitmapTransformation(ITransformable transformation)
        {
            var f = new BitmapTransformation(transformation);
            if (transformation is IProgressTracking) {
                var progressBarForm = new ProgressForm {
                    Text = "Идёт применение фильтра: {0} (0%)".F(transformation.ToString())
                };
                progressBarForm.Show();
                var trackingObj = transformation as IProgressTracking;
                trackingObj.ProgressChanged += (s, p) => BeginInvoke((MethodInvoker)delegate {
                    progressBarForm.Progress.Value = p.Progress;
                    progressBarForm.Text = "Идёт применение фильтра: {0} ({1}%)"
                        .F(transformation.ToString(), p.Progress);
                });
                trackingObj.OperationComplete += (s, p) => BeginInvoke((MethodInvoker)progressBarForm.Close);
            }
            if (transformation is IСonfigurable) {
                var optionsWin = new TransformationOptions {
                    PreviewBitmap = (Bitmap) _workingBitmap.Clone()
                };
                optionsWin.Show();
            }
            _workingBitmap = await Task<Bitmap>.Factory.StartNew(() => f.Apply(_workingBitmap));
            _history.SaveState(_workingBitmap);
            UpdateMenuHistoryItems();
            SyncPicture();
        }


        /// <summary>
        /// Отображает диалог открытия файла и открывает выбранный файл
        /// </summary>
        private void LoadImage(string fileName)
        {
            try {
                var ms = new MemoryStream(File.ReadAllBytes(fileName));
                var bitmap = (Bitmap)Image.FromStream(ms);
                _workingBitmap = bitmap;
                _workingBitmapFormat = bitmap.GetImageFormat();
                _loadedFileName = fileName;
                // Сохранем состояние исходного изображения
                _history.SaveState(_workingBitmap);
                // Обновляем изображение в PictureBox
                SyncPicture();
            } catch (Exception ex)
            {
                const string msg = "При открытии файла произошла ошибка: {0}";
                MessageBox.Show(msg.F(ex.Message), @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveImage(string fileName, ImageFormat format)
        {
            try {
                _workingBitmap.Save(fileName, format);
            } catch (Exception ex)
            {
                const string msg = "При сохранении файла произошла ошибка: {0}";
                MessageBox.Show(msg.F(ex.Message), @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Синхронизирует изображение на форме с рабочим изображением
        /// </summary>
        public void SyncPicture()
        {
            if (_workingBitmap != null) {
                PictureLoaded.Image = _workingBitmap;
            }
        }

        private void UpdateMenuHistoryItems()
        {
            MenuEditUndo.Enabled = _history.CanUndo();
            MenuEditRedo.Enabled = _history.CanRedo();
        }

        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
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
            _workingBitmap.Save(_loadedFileName, _workingBitmapFormat);
        }

        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (_workingBitmap == null) return;
            var dialog = new SaveFileDialog {
                Filter = @"Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png",
                Title  = @"Save an Image File"
            };
            if (dialog.ShowDialog() != DialogResult.OK || dialog.FileName.Equals("")) return;
            var format = ImageFormat.Bmp;
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
            if (! _history.CanUndo()) return;
            _workingBitmap = _history.Undo();
            UpdateMenuHistoryItems();
            SyncPicture();
        }

        private void MenuEditRedo_Click(object sender, EventArgs e)
        {
            if (!_history.CanRedo()) return;
            _workingBitmap = _history.Redo();
            UpdateMenuHistoryItems();
            SyncPicture();
        }

        private void MenuImageRotate180_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TfRotate(RotateType.A180));
        }

        private void MneuImageFlipHorizontal_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TfFlip(FlipType.Horizontal));
        }

        private void MenuImageFlipVertical_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TfFlip(FlipType.Vertical));
        }

        private void MenuImageRotate90Clockwise_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TfRotate(RotateType.Clockwise));
        }

        private void MenuImageRotate90CounterClockwise_Click(object sender, EventArgs e)
        {
            ApplyBitmapTransformation(new TfRotate(RotateType.Counterclockwise));
        }

        private void MenuEditPreferences_Click(object sender, EventArgs e)
        {
            var pref = new PreferencesForm();
            pref.ShowDialog();
            pref.Dispose();
        }

        private void MenuViewSizeModeDefault_Click(object sender, EventArgs e)
        {
            PictureLoaded.Dock = DockStyle.None;
            PictureLoaded.SizeMode = PictureBoxSizeMode.AutoSize;
            MenuViewSizeModeDefault.CheckState = CheckState.Checked;
            MenuViewSizeModeStretch.CheckState = CheckState.Unchecked;
            MenuViewSizeModeZoom.CheckState = CheckState.Unchecked;
        }

        private void MenuViewSizeModeStretch_Click(object sender, EventArgs e)
        {
            PictureLoaded.Dock = DockStyle.Fill;
            PictureLoaded.SizeMode = PictureBoxSizeMode.StretchImage;
            MenuViewSizeModeStretch.CheckState = CheckState.Checked;
            MenuViewSizeModeDefault.CheckState = CheckState.Unchecked;
            MenuViewSizeModeZoom.CheckState = CheckState.Unchecked;
        }

        private void MenuViewSizeModeZoom_Click(object sender, EventArgs e)
        {
            PictureLoaded.Dock = DockStyle.Fill;
            PictureLoaded.SizeMode = PictureBoxSizeMode.Zoom;
            MenuViewSizeModeZoom.CheckState = CheckState.Checked;
            MenuViewSizeModeStretch.CheckState = CheckState.Unchecked;
            MenuViewSizeModeDefault.CheckState = CheckState.Unchecked;
        }

    }
}
