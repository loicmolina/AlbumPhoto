namespace AlbumPhoto
{
    partial class PreferenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferenceForm));
            this.button_browse_folder = new System.Windows.Forms.Button();
            this.textBox_folder_path = new System.Windows.Forms.TextBox();
            this.button_accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_browse_folder
            // 
            this.button_browse_folder.Location = new System.Drawing.Point(356, 46);
            this.button_browse_folder.Name = "button_browse_folder";
            this.button_browse_folder.Size = new System.Drawing.Size(25, 20);
            this.button_browse_folder.TabIndex = 0;
            this.button_browse_folder.Text = "...";
            this.button_browse_folder.UseVisualStyleBackColor = true;
            this.button_browse_folder.Click += new System.EventHandler(this.button_browse_folder_Click);
            // 
            // textBox_folder_path
            // 
            this.textBox_folder_path.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_folder_path.Location = new System.Drawing.Point(27, 46);
            this.textBox_folder_path.Name = "textBox_folder_path";
            this.textBox_folder_path.ReadOnly = true;
            this.textBox_folder_path.Size = new System.Drawing.Size(306, 20);
            this.textBox_folder_path.TabIndex = 1;
            // 
            // button_accept
            // 
            this.button_accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_accept.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_accept.Location = new System.Drawing.Point(169, 103);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(75, 23);
            this.button_accept.TabIndex = 2;
            this.button_accept.Text = "Valider";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chemin du dossier source :";
            // 
            // PreferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(414, 156);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.textBox_folder_path);
            this.Controls.Add(this.button_browse_folder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreferenceForm";
            this.Text = "Localisation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_browse_folder;
        private System.Windows.Forms.TextBox textBox_folder_path;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Label label1;
    }
}