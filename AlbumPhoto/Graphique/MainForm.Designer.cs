namespace ProjetAlbum
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_import_image = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_display_img = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localisationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listePhotos = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_import_image
            // 
            this.button_import_image.Location = new System.Drawing.Point(4, 43);
            this.button_import_image.Margin = new System.Windows.Forms.Padding(4);
            this.button_import_image.Name = "button_import_image";
            this.button_import_image.Size = new System.Drawing.Size(180, 34);
            this.button_import_image.TabIndex = 0;
            this.button_import_image.Text = "Importer une image";
            this.button_import_image.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(4, 81);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(179, 388);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button_display_img
            // 
            this.button_display_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_display_img.Location = new System.Drawing.Point(4, 474);
            this.button_display_img.Margin = new System.Windows.Forms.Padding(4);
            this.button_display_img.Name = "button_display_img";
            this.button_display_img.Size = new System.Drawing.Size(180, 25);
            this.button_display_img.TabIndex = 5;
            this.button_display_img.Text = "Afficher l\'image";
            this.button_display_img.UseVisualStyleBackColor = true;
            this.button_display_img.Click += new System.EventHandler(this.button_display_img_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1472, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localisationToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // localisationToolStripMenuItem
            // 
            this.localisationToolStripMenuItem.Name = "localisationToolStripMenuItem";
            this.localisationToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.localisationToolStripMenuItem.Text = "Localisation";
            this.localisationToolStripMenuItem.Click += new System.EventHandler(this.localisationToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.LargeImageList = this.listePhotos;
            this.listView1.Location = new System.Drawing.Point(192, 43);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1103, 454);
            this.listView1.SmallImageList = this.listePhotos;
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listePhotos
            // 
            this.listePhotos.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.listePhotos.ImageSize = new System.Drawing.Size(200, 200);
            this.listePhotos.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 507);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_display_img);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_import_image);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_import_image;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_display_img;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localisationToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList listePhotos;
    }
}

