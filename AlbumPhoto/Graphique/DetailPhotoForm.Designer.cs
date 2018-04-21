using System.Windows.Forms;

namespace AlbumPhoto.Graphique
{
    partial class DetailPhotoForm
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
            if (disposing && (components != null))
            {
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
            this.labelName = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.labeTags = new System.Windows.Forms.Label();
            this.labelPictureName = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(399, 16);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nom :";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(498, 366);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Enregistrer";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // textBoxTags
            // 
            this.textBoxTags.Location = new System.Drawing.Point(443, 99);
            this.textBoxTags.Multiline = true;
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(212, 214);
            this.textBoxTags.TabIndex = 5;
            // 
            // labeTags
            // 
            this.labeTags.AutoSize = true;
            this.labeTags.Location = new System.Drawing.Point(401, 102);
            this.labeTags.Name = "labeTags";
            this.labeTags.Size = new System.Drawing.Size(37, 13);
            this.labeTags.TabIndex = 4;
            this.labeTags.Text = "Tags :";
            // 
            // labelPictureName
            // 
            this.labelPictureName.AutoSize = true;
            this.labelPictureName.Location = new System.Drawing.Point(440, 16);
            this.labelPictureName.Name = "labelPictureName";
            this.labelPictureName.Size = new System.Drawing.Size(35, 13);
            this.labelPictureName.TabIndex = 6;
            this.labelPictureName.Text = "label1";
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(12, 16);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(362, 373);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 7;
            this.image.TabStop = false;
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Location = new System.Drawing.Point(402, 52);
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(253, 45);
            this.trackBarZoom.TabIndex = 9;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // DetailPhotoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(679, 407);
            this.Controls.Add(this.trackBarZoom);
            this.Controls.Add(this.image);
            this.Controls.Add(this.labelPictureName);
            this.Controls.Add(this.textBoxTags);
            this.Controls.Add(this.labeTags);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DetailPhotoForm";
            this.Text = "DetailPhotoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetailPhotoForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Label labeTags;
        private System.Windows.Forms.Label labelPictureName;
        private PictureBox image;
        private TrackBar trackBarZoom;
    }
}