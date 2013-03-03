namespace ImageEditor
{
    partial class TransformationOptions
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
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PreviewBox = new System.Windows.Forms.PictureBox();
            this.PreviewImagePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.OptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).BeginInit();
            this.PreviewImagePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.LayoutPanel);
            this.OptionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(284, 295);
            this.OptionsGroupBox.TabIndex = 0;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.Size = new System.Drawing.Size(278, 276);
            this.LayoutPanel.TabIndex = 0;
            // 
            // PreviewBox
            // 
            this.PreviewBox.Location = new System.Drawing.Point(0, 0);
            this.PreviewBox.Name = "PreviewBox";
            this.PreviewBox.Size = new System.Drawing.Size(44, 42);
            this.PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PreviewBox.TabIndex = 1;
            this.PreviewBox.TabStop = false;
            // 
            // PreviewImagePanel
            // 
            this.PreviewImagePanel.AutoScroll = true;
            this.PreviewImagePanel.Controls.Add(this.PreviewBox);
            this.PreviewImagePanel.Location = new System.Drawing.Point(6, 16);
            this.PreviewImagePanel.Name = "PreviewImagePanel";
            this.PreviewImagePanel.Size = new System.Drawing.Size(331, 331);
            this.PreviewImagePanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PreviewImagePanel);
            this.groupBox1.Location = new System.Drawing.Point(306, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(12, 313);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(130, 49);
            this.ButtonOk.TabIndex = 2;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(166, 313);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(130, 49);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // TransformationOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 370);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OptionsGroupBox);
            this.Name = "TransformationOptions";
            this.Text = "Transformation Options";
            this.Load += new System.EventHandler(this.TransformationOptions_Load);
            this.OptionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).EndInit();
            this.PreviewImagePanel.ResumeLayout(false);
            this.PreviewImagePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox OptionsGroupBox;
        public System.Windows.Forms.FlowLayoutPanel LayoutPanel;
        private System.Windows.Forms.PictureBox PreviewBox;
        private System.Windows.Forms.Panel PreviewImagePanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;

    }
}