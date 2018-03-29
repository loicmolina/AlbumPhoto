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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listAlbums = new System.Windows.Forms.ListBox();
            this.buttonNewAlbum = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localisationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listePhotos = new System.Windows.Forms.ImageList(this.components);
            this.nameNewAlbum = new System.Windows.Forms.TextBox();
            this.buttonImportPhoto = new System.Windows.Forms.Button();
            this.buttonImportAlbum = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listAlbums
            // 
            this.listAlbums.FormattingEnabled = true;
            this.listAlbums.Location = new System.Drawing.Point(3, 74);
            this.listAlbums.Name = "listAlbums";
            this.listAlbums.Size = new System.Drawing.Size(136, 784);
            this.listAlbums.TabIndex = 2;
            this.listAlbums.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonNewAlbum
            // 
            this.buttonNewAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNewAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewAlbum.Image = ((System.Drawing.Image)(resources.GetObject("buttonNewAlbum.Image")));
            this.buttonNewAlbum.Location = new System.Drawing.Point(64, 35);
            this.buttonNewAlbum.Name = "buttonNewAlbum";
            this.buttonNewAlbum.Size = new System.Drawing.Size(38, 33);
            this.buttonNewAlbum.TabIndex = 5;
            this.buttonNewAlbum.UseVisualStyleBackColor = true;
            this.buttonNewAlbum.Click += new System.EventHandler(this.button_AddAlbum);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1504, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localisationToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // localisationToolStripMenuItem
            // 
            this.localisationToolStripMenuItem.Name = "localisationToolStripMenuItem";
            this.localisationToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.localisationToolStripMenuItem.Text = "Localisation";
            this.localisationToolStripMenuItem.Click += new System.EventHandler(this.localisationToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.LargeImageList = this.listePhotos;
            this.listView1.Location = new System.Drawing.Point(144, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1350, 784);
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
            // nameNewAlbum
            // 
            this.nameNewAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameNewAlbum.Location = new System.Drawing.Point(3, 36);
            this.nameNewAlbum.Multiline = true;
            this.nameNewAlbum.Name = "nameNewAlbum";
            this.nameNewAlbum.Size = new System.Drawing.Size(62, 31);
            this.nameNewAlbum.TabIndex = 8;
            // 
            // buttonImportPhoto
            // 
            this.buttonImportPhoto.Image = ((System.Drawing.Image)(resources.GetObject("buttonImportPhoto.Image")));
            this.buttonImportPhoto.Location = new System.Drawing.Point(144, 35);
            this.buttonImportPhoto.Name = "buttonImportPhoto";
            this.buttonImportPhoto.Size = new System.Drawing.Size(38, 33);
            this.buttonImportPhoto.TabIndex = 10;
            this.buttonImportPhoto.UseVisualStyleBackColor = true;
            this.buttonImportPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // buttonImportAlbum
            // 
            this.buttonImportAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonImportAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImportAlbum.Image = ((System.Drawing.Image)(resources.GetObject("buttonImportAlbum.Image")));
            this.buttonImportAlbum.Location = new System.Drawing.Point(101, 35);
            this.buttonImportAlbum.Name = "buttonImportAlbum";
            this.buttonImportAlbum.Size = new System.Drawing.Size(38, 33);
            this.buttonImportAlbum.TabIndex = 11;
            this.buttonImportAlbum.UseVisualStyleBackColor = true;
            this.buttonImportAlbum.Click += new System.EventHandler(this.buttonImportAlbum_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 861);
            this.Controls.Add(this.buttonImportAlbum);
            this.Controls.Add(this.buttonImportPhoto);
            this.Controls.Add(this.nameNewAlbum);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonNewAlbum);
            this.Controls.Add(this.listAlbums);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listAlbums;
        private System.Windows.Forms.Button buttonNewAlbum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localisationToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList listePhotos;
        private System.Windows.Forms.TextBox nameNewAlbum;
        private System.Windows.Forms.Button buttonImportPhoto;
        private System.Windows.Forms.Button buttonImportAlbum;
    }
}

