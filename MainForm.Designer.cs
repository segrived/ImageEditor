namespace ImageEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuEditPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuViewSizeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuViewSizeModeDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuViewSizeModeStretch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuViewSizeModeZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImageRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImageRotate90Clockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImageRotate90CounterClockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImageRotate180 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImageFlip = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImageFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.MneuImageFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdjustments = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEffects = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelImage = new System.Windows.Forms.Panel();
            this.PictureLoaded = new System.Windows.Forms.PictureBox();
            this.FormMenu.SuspendLayout();
            this.PanelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoaded)).BeginInit();
            this.SuspendLayout();
            // 
            // FormMenu
            // 
            this.FormMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuEdit,
            this.MenuView,
            this.MenuImage,
            this.MenuAdjustments,
            this.MenuEffects,
            this.MenuHelp});
            this.FormMenu.Location = new System.Drawing.Point(0, 0);
            this.FormMenu.Name = "FormMenu";
            this.FormMenu.Size = new System.Drawing.Size(640, 24);
            this.FormMenu.TabIndex = 0;
            this.FormMenu.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileOpen,
            this.MenuFileSave,
            this.MenuFileSaveAs,
            this.MenuFileSeparator,
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "File";
            // 
            // MenuFileOpen
            // 
            this.MenuFileOpen.Name = "MenuFileOpen";
            this.MenuFileOpen.Size = new System.Drawing.Size(121, 22);
            this.MenuFileOpen.Text = "Open";
            this.MenuFileOpen.Click += new System.EventHandler(this.MenuFileOpen_Click);
            // 
            // MenuFileSave
            // 
            this.MenuFileSave.Enabled = false;
            this.MenuFileSave.Name = "MenuFileSave";
            this.MenuFileSave.Size = new System.Drawing.Size(121, 22);
            this.MenuFileSave.Text = "Save";
            this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
            // 
            // MenuFileSaveAs
            // 
            this.MenuFileSaveAs.Enabled = false;
            this.MenuFileSaveAs.Name = "MenuFileSaveAs";
            this.MenuFileSaveAs.Size = new System.Drawing.Size(121, 22);
            this.MenuFileSaveAs.Text = "Save as...";
            this.MenuFileSaveAs.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
            // 
            // MenuFileSeparator
            // 
            this.MenuFileSeparator.Name = "MenuFileSeparator";
            this.MenuFileSeparator.Size = new System.Drawing.Size(118, 6);
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(121, 22);
            this.MenuFileExit.Text = "Exit";
            this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // MenuEdit
            // 
            this.MenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEditUndo,
            this.MenuEditRedo,
            this.toolStripMenuItem1,
            this.MenuEditPreferences});
            this.MenuEdit.Name = "MenuEdit";
            this.MenuEdit.Size = new System.Drawing.Size(39, 20);
            this.MenuEdit.Text = "Edit";
            // 
            // MenuEditUndo
            // 
            this.MenuEditUndo.Name = "MenuEditUndo";
            this.MenuEditUndo.Size = new System.Drawing.Size(135, 22);
            this.MenuEditUndo.Text = "Undo";
            this.MenuEditUndo.Click += new System.EventHandler(this.MenuEditUndo_Click);
            // 
            // MenuEditRedo
            // 
            this.MenuEditRedo.Name = "MenuEditRedo";
            this.MenuEditRedo.Size = new System.Drawing.Size(135, 22);
            this.MenuEditRedo.Text = "Redo";
            this.MenuEditRedo.Click += new System.EventHandler(this.MenuEditRedo_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 6);
            // 
            // MenuEditPreferences
            // 
            this.MenuEditPreferences.Name = "MenuEditPreferences";
            this.MenuEditPreferences.Size = new System.Drawing.Size(135, 22);
            this.MenuEditPreferences.Text = "Preferences";
            this.MenuEditPreferences.Click += new System.EventHandler(this.MenuEditPreferences_Click);
            // 
            // MenuView
            // 
            this.MenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuViewSizeMode});
            this.MenuView.Name = "MenuView";
            this.MenuView.Size = new System.Drawing.Size(44, 20);
            this.MenuView.Text = "View";
            // 
            // MenuViewSizeMode
            // 
            this.MenuViewSizeMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuViewSizeModeDefault,
            this.MenuViewSizeModeStretch,
            this.MenuViewSizeModeZoom});
            this.MenuViewSizeMode.Name = "MenuViewSizeMode";
            this.MenuViewSizeMode.Size = new System.Drawing.Size(152, 22);
            this.MenuViewSizeMode.Text = "Size Mode";
            // 
            // MenuViewSizeModeDefault
            // 
            this.MenuViewSizeModeDefault.Checked = true;
            this.MenuViewSizeModeDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuViewSizeModeDefault.Name = "MenuViewSizeModeDefault";
            this.MenuViewSizeModeDefault.Size = new System.Drawing.Size(152, 22);
            this.MenuViewSizeModeDefault.Text = "Default";
            this.MenuViewSizeModeDefault.Click += new System.EventHandler(this.MenuViewSizeModeDefault_Click);
            // 
            // MenuViewSizeModeStretch
            // 
            this.MenuViewSizeModeStretch.Name = "MenuViewSizeModeStretch";
            this.MenuViewSizeModeStretch.Size = new System.Drawing.Size(152, 22);
            this.MenuViewSizeModeStretch.Text = "Stretch";
            this.MenuViewSizeModeStretch.Click += new System.EventHandler(this.MenuViewSizeModeStretch_Click);
            // 
            // MenuViewSizeModeZoom
            // 
            this.MenuViewSizeModeZoom.Name = "MenuViewSizeModeZoom";
            this.MenuViewSizeModeZoom.Size = new System.Drawing.Size(152, 22);
            this.MenuViewSizeModeZoom.Text = "Zoom";
            this.MenuViewSizeModeZoom.Click += new System.EventHandler(this.MenuViewSizeModeZoom_Click);
            // 
            // MenuImage
            // 
            this.MenuImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuImageRotate,
            this.MenuImageFlip});
            this.MenuImage.Enabled = false;
            this.MenuImage.Name = "MenuImage";
            this.MenuImage.Size = new System.Drawing.Size(52, 20);
            this.MenuImage.Text = "Image";
            // 
            // MenuImageRotate
            // 
            this.MenuImageRotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuImageRotate90Clockwise,
            this.MenuImageRotate90CounterClockwise,
            this.MenuImageRotate180});
            this.MenuImageRotate.Name = "MenuImageRotate";
            this.MenuImageRotate.Size = new System.Drawing.Size(108, 22);
            this.MenuImageRotate.Text = "Rotate";
            // 
            // MenuImageRotate90Clockwise
            // 
            this.MenuImageRotate90Clockwise.Name = "MenuImageRotate90Clockwise";
            this.MenuImageRotate90Clockwise.Size = new System.Drawing.Size(195, 22);
            this.MenuImageRotate90Clockwise.Text = "90° Clockwise";
            this.MenuImageRotate90Clockwise.Click += new System.EventHandler(this.MenuImageRotate90Clockwise_Click);
            // 
            // MenuImageRotate90CounterClockwise
            // 
            this.MenuImageRotate90CounterClockwise.Name = "MenuImageRotate90CounterClockwise";
            this.MenuImageRotate90CounterClockwise.Size = new System.Drawing.Size(195, 22);
            this.MenuImageRotate90CounterClockwise.Text = "90° Counter-Clockwise";
            this.MenuImageRotate90CounterClockwise.Click += new System.EventHandler(this.MenuImageRotate90CounterClockwise_Click);
            // 
            // MenuImageRotate180
            // 
            this.MenuImageRotate180.Name = "MenuImageRotate180";
            this.MenuImageRotate180.Size = new System.Drawing.Size(195, 22);
            this.MenuImageRotate180.Text = "180°";
            this.MenuImageRotate180.Click += new System.EventHandler(this.MenuImageRotate180_Click);
            // 
            // MenuImageFlip
            // 
            this.MenuImageFlip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuImageFlipVertical,
            this.MneuImageFlipHorizontal});
            this.MenuImageFlip.Name = "MenuImageFlip";
            this.MenuImageFlip.Size = new System.Drawing.Size(108, 22);
            this.MenuImageFlip.Text = "Flip";
            // 
            // MenuImageFlipVertical
            // 
            this.MenuImageFlipVertical.Name = "MenuImageFlipVertical";
            this.MenuImageFlipVertical.Size = new System.Drawing.Size(129, 22);
            this.MenuImageFlipVertical.Text = "Vertical";
            this.MenuImageFlipVertical.Click += new System.EventHandler(this.MenuImageFlipVertical_Click);
            // 
            // MneuImageFlipHorizontal
            // 
            this.MneuImageFlipHorizontal.Name = "MneuImageFlipHorizontal";
            this.MneuImageFlipHorizontal.Size = new System.Drawing.Size(129, 22);
            this.MneuImageFlipHorizontal.Text = "Horizontal";
            this.MneuImageFlipHorizontal.Click += new System.EventHandler(this.MneuImageFlipHorizontal_Click);
            // 
            // MenuAdjustments
            // 
            this.MenuAdjustments.Enabled = false;
            this.MenuAdjustments.Name = "MenuAdjustments";
            this.MenuAdjustments.Size = new System.Drawing.Size(86, 20);
            this.MenuAdjustments.Text = "Adjustments";
            // 
            // MenuEffects
            // 
            this.MenuEffects.Enabled = false;
            this.MenuEffects.Name = "MenuEffects";
            this.MenuEffects.Size = new System.Drawing.Size(54, 20);
            this.MenuEffects.Text = "Effects";
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuHelp.Text = "Help";
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.MenuHelpAbout.Text = "About";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // PanelImage
            // 
            this.PanelImage.AutoScroll = true;
            this.PanelImage.Controls.Add(this.PictureLoaded);
            this.PanelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelImage.Location = new System.Drawing.Point(0, 24);
            this.PanelImage.Name = "PanelImage";
            this.PanelImage.Size = new System.Drawing.Size(640, 395);
            this.PanelImage.TabIndex = 1;
            // 
            // PictureLoaded
            // 
            this.PictureLoaded.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureLoaded.Location = new System.Drawing.Point(0, 0);
            this.PictureLoaded.Name = "PictureLoaded";
            this.PictureLoaded.Size = new System.Drawing.Size(100, 50);
            this.PictureLoaded.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureLoaded.TabIndex = 1;
            this.PictureLoaded.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 419);
            this.Controls.Add(this.PanelImage);
            this.Controls.Add(this.FormMenu);
            this.MainMenuStrip = this.FormMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Editor";
            this.FormMenu.ResumeLayout(false);
            this.FormMenu.PerformLayout();
            this.PanelImage.ResumeLayout(false);
            this.PanelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoaded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FormMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator MenuFileSeparator;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuImage;
        private System.Windows.Forms.ToolStripMenuItem MenuImageRotate;
        private System.Windows.Forms.ToolStripMenuItem MenuImageFlip;
        private System.Windows.Forms.ToolStripMenuItem MenuImageFlipVertical;
        private System.Windows.Forms.ToolStripMenuItem MneuImageFlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem MenuAdjustments;
        private System.Windows.Forms.ToolStripMenuItem MenuEffects;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem MenuImageRotate90Clockwise;
        private System.Windows.Forms.ToolStripMenuItem MenuImageRotate90CounterClockwise;
        private System.Windows.Forms.ToolStripMenuItem MenuImageRotate180;
        private System.Windows.Forms.ToolStripMenuItem MenuEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuView;
        private System.Windows.Forms.Panel PanelImage;
        private System.Windows.Forms.PictureBox PictureLoaded;
        private System.Windows.Forms.ToolStripMenuItem MenuEditUndo;
        private System.Windows.Forms.ToolStripMenuItem MenuEditRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuEditPreferences;
        private System.Windows.Forms.ToolStripMenuItem MenuViewSizeMode;
        private System.Windows.Forms.ToolStripMenuItem MenuViewSizeModeStretch;
        private System.Windows.Forms.ToolStripMenuItem MenuViewSizeModeDefault;
        private System.Windows.Forms.ToolStripMenuItem MenuViewSizeModeZoom;
    }
}

