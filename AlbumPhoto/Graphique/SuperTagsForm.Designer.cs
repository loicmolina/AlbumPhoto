namespace AlbumPhoto.Graphique
{
    partial class SuperTagsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperTagsForm));
            this.treeViewTags = new System.Windows.Forms.TreeView();
            this.textBoxSuperTag = new System.Windows.Forms.TextBox();
            this.buttonAddSuperTag = new System.Windows.Forms.Button();
            this.buttonDelSuperTag = new System.Windows.Forms.Button();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.buttonDelTag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewTags
            // 
            this.treeViewTags.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeViewTags.Location = new System.Drawing.Point(13, 72);
            this.treeViewTags.Name = "treeViewTags";
            this.treeViewTags.Size = new System.Drawing.Size(259, 363);
            this.treeViewTags.TabIndex = 0;
            // 
            // textBoxSuperTag
            // 
            this.textBoxSuperTag.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxSuperTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSuperTag.Location = new System.Drawing.Point(13, 13);
            this.textBoxSuperTag.Name = "textBoxSuperTag";
            this.textBoxSuperTag.Size = new System.Drawing.Size(169, 21);
            this.textBoxSuperTag.TabIndex = 1;
            this.textBoxSuperTag.Text = "Ajouter un super tag...";
            this.textBoxSuperTag.Click += new System.EventHandler(this.textBoxSuperTag_Click);
            // 
            // buttonAddSuperTag
            // 
            this.buttonAddSuperTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSuperTag.Location = new System.Drawing.Point(188, 12);
            this.buttonAddSuperTag.Name = "buttonAddSuperTag";
            this.buttonAddSuperTag.Size = new System.Drawing.Size(32, 23);
            this.buttonAddSuperTag.TabIndex = 2;
            this.buttonAddSuperTag.Text = "+";
            this.buttonAddSuperTag.UseVisualStyleBackColor = true;
            this.buttonAddSuperTag.Click += new System.EventHandler(this.buttonAddSuperTag_Click);
            // 
            // buttonDelSuperTag
            // 
            this.buttonDelSuperTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelSuperTag.Location = new System.Drawing.Point(240, 12);
            this.buttonDelSuperTag.Name = "buttonDelSuperTag";
            this.buttonDelSuperTag.Size = new System.Drawing.Size(32, 23);
            this.buttonDelSuperTag.TabIndex = 3;
            this.buttonDelSuperTag.Text = "-";
            this.buttonDelSuperTag.UseVisualStyleBackColor = true;
            this.buttonDelSuperTag.Click += new System.EventHandler(this.buttonDelSuperTag_Click);
            // 
            // textBoxTag
            // 
            this.textBoxTag.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxTag.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTag.Location = new System.Drawing.Point(13, 43);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(169, 20);
            this.textBoxTag.TabIndex = 4;
            this.textBoxTag.Text = "Assigner un tag à un super tag...";
            this.textBoxTag.Click += new System.EventHandler(this.textBoxTag_Click);
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddTag.Location = new System.Drawing.Point(188, 43);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(32, 22);
            this.buttonAddTag.TabIndex = 5;
            this.buttonAddTag.Text = "+";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // buttonDelTag
            // 
            this.buttonDelTag.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelTag.Location = new System.Drawing.Point(240, 43);
            this.buttonDelTag.Name = "buttonDelTag";
            this.buttonDelTag.Size = new System.Drawing.Size(32, 23);
            this.buttonDelTag.TabIndex = 6;
            this.buttonDelTag.Text = "-";
            this.buttonDelTag.UseVisualStyleBackColor = true;
            this.buttonDelTag.Click += new System.EventHandler(this.buttonDelTag_Click);
            // 
            // SuperTagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(284, 453);
            this.Controls.Add(this.buttonDelTag);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.buttonDelSuperTag);
            this.Controls.Add(this.buttonAddSuperTag);
            this.Controls.Add(this.textBoxSuperTag);
            this.Controls.Add(this.treeViewTags);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuperTagsForm";
            this.Text = "Gestions des tags";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuperTagsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewTags;
        private System.Windows.Forms.TextBox textBoxSuperTag;
        private System.Windows.Forms.Button buttonAddSuperTag;
        private System.Windows.Forms.Button buttonDelSuperTag;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Button buttonDelTag;
    }
}