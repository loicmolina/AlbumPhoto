using System.Windows.Forms;

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
            this.listPhotos = new System.Windows.Forms.ImageList(this.components);
            this.nameNewAlbum = new System.Windows.Forms.TextBox();
            this.buttonImportPhoto = new System.Windows.Forms.Button();
            this.buttonDelAlbum = new System.Windows.Forms.Button();
            this.buttonDelImage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listPictures = new System.Windows.Forms.ListView();
            this.textBoxRecherche = new System.Windows.Forms.TextBox();
            this.buttonRecherche = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.comboBoxAlbums = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listAlbums
            // 
            this.listAlbums.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listAlbums.FormattingEnabled = true;
            this.listAlbums.Location = new System.Drawing.Point(3, 77);
            this.listAlbums.Name = "listAlbums";
            this.listAlbums.Size = new System.Drawing.Size(149, 459);
            this.listAlbums.TabIndex = 2;
            this.listAlbums.SelectedIndexChanged += new System.EventHandler(this.ListAlbums_SelectedIndexChanged);
            // 
            // buttonNewAlbum
            // 
            this.buttonNewAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNewAlbum.Enabled = false;
            this.buttonNewAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewAlbum.Image = ((System.Drawing.Image)(resources.GetObject("buttonNewAlbum.Image")));
            this.buttonNewAlbum.Location = new System.Drawing.Point(74, 35);
            this.buttonNewAlbum.Name = "buttonNewAlbum";
            this.buttonNewAlbum.Size = new System.Drawing.Size(38, 33);
            this.buttonNewAlbum.TabIndex = 5;
            this.buttonNewAlbum.UseVisualStyleBackColor = true;
            this.buttonNewAlbum.Click += new System.EventHandler(this.ButtonAddAlbum_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1499, 24);
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
            this.localisationToolStripMenuItem.Click += new System.EventHandler(this.LocalisationToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
            // 
            // listPhotos
            // 
            this.listPhotos.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.listPhotos.ImageSize = new System.Drawing.Size(256, 256);
            this.listPhotos.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // nameNewAlbum
            // 
            this.nameNewAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameNewAlbum.Location = new System.Drawing.Point(3, 37);
            this.nameNewAlbum.Name = "nameNewAlbum";
            this.nameNewAlbum.Size = new System.Drawing.Size(69, 26);
            this.nameNewAlbum.TabIndex = 8;
            // 
            // buttonImportPhoto
            // 
            this.buttonImportPhoto.Enabled = false;
            this.buttonImportPhoto.Image = ((System.Drawing.Image)(resources.GetObject("buttonImportPhoto.Image")));
            this.buttonImportPhoto.Location = new System.Drawing.Point(158, 35);
            this.buttonImportPhoto.Name = "buttonImportPhoto";
            this.buttonImportPhoto.Size = new System.Drawing.Size(38, 33);
            this.buttonImportPhoto.TabIndex = 10;
            this.buttonImportPhoto.UseVisualStyleBackColor = true;
            this.buttonImportPhoto.Click += new System.EventHandler(this.ButtonAddPhoto_Click);
            // 
            // buttonDelAlbum
            // 
            this.buttonDelAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonDelAlbum.Enabled = false;
            this.buttonDelAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelAlbum.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelAlbum.Image")));
            this.buttonDelAlbum.Location = new System.Drawing.Point(114, 35);
            this.buttonDelAlbum.Name = "buttonDelAlbum";
            this.buttonDelAlbum.Size = new System.Drawing.Size(38, 33);
            this.buttonDelAlbum.TabIndex = 11;
            this.buttonDelAlbum.UseVisualStyleBackColor = true;
            this.buttonDelAlbum.Click += new System.EventHandler(this.ButtonDelAlbum_Click);
            // 
            // buttonDelImage
            // 
            this.buttonDelImage.Enabled = false;
            this.buttonDelImage.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelImage.Image")));
            this.buttonDelImage.Location = new System.Drawing.Point(195, 35);
            this.buttonDelImage.Name = "buttonDelImage";
            this.buttonDelImage.Size = new System.Drawing.Size(38, 33);
            this.buttonDelImage.TabIndex = 12;
            this.buttonDelImage.UseVisualStyleBackColor = true;
            this.buttonDelImage.Click += new System.EventHandler(this.ButtonDelImage_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 557);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listPictures
            // 
            this.listPictures.AllowDrop = true;
            this.listPictures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPictures.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listPictures.LargeImageList = this.listPhotos;
            this.listPictures.Location = new System.Drawing.Point(159, 77);
            this.listPictures.Name = "listPictures";
            this.listPictures.Size = new System.Drawing.Size(1336, 781);
            this.listPictures.SmallImageList = this.listPhotos;
            this.listPictures.TabIndex = 7;
            this.listPictures.UseCompatibleStateImageBehavior = false;
            this.listPictures.SelectedIndexChanged += new System.EventHandler(this.ListPictures_SelectedIndexChanged);
            this.listPictures.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListPictures_DragDrop);
            this.listPictures.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListPictures_DragEnter);
            this.listPictures.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListPictures_MouseDoubleClick);
            // 
            // textBoxRecherche
            // 
            this.textBoxRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRecherche.Location = new System.Drawing.Point(1073, 49);
            this.textBoxRecherche.Name = "textBoxRecherche";
            this.textBoxRecherche.Size = new System.Drawing.Size(346, 20);
            this.textBoxRecherche.TabIndex = 16;
            this.textBoxRecherche.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxRecherche_KeyDown);
            // 
            // buttonRecherche
            // 
            this.buttonRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRecherche.Location = new System.Drawing.Point(1420, 49);
            this.buttonRecherche.Name = "buttonRecherche";
            this.buttonRecherche.Size = new System.Drawing.Size(75, 22);
            this.buttonRecherche.TabIndex = 17;
            this.buttonRecherche.Text = "Rechercher";
            this.buttonRecherche.UseVisualStyleBackColor = true;
            this.buttonRecherche.Click += new System.EventHandler(this.ButtonRecherche_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(3, 835);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(149, 23);
            this.progressBar.TabIndex = 18;
            // 
            // comboBoxAlbums
            // 
            this.comboBoxAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAlbums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlbums.FormattingEnabled = true;
            this.comboBoxAlbums.Items.AddRange(new object[] {
            "Tous"});
            this.comboBoxAlbums.Location = new System.Drawing.Point(960, 49);
            this.comboBoxAlbums.Name = "comboBoxAlbums";
            this.comboBoxAlbums.Size = new System.Drawing.Size(107, 21);
            this.comboBoxAlbums.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1499, 861);
            this.Controls.Add(this.comboBoxAlbums);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonRecherche);
            this.Controls.Add(this.textBoxRecherche);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDelImage);
            this.Controls.Add(this.buttonDelAlbum);
            this.Controls.Add(this.buttonImportPhoto);
            this.Controls.Add(this.nameNewAlbum);
            this.Controls.Add(this.listPictures);
            this.Controls.Add(this.buttonNewAlbum);
            this.Controls.Add(this.listAlbums);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Gestion d\'albums photo";
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
        private System.Windows.Forms.ImageList listPhotos;
        private System.Windows.Forms.TextBox nameNewAlbum;
        private System.Windows.Forms.Button buttonImportPhoto;
        private System.Windows.Forms.Button buttonDelAlbum;
        private System.Windows.Forms.Button buttonDelImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listPictures;
        private TextBox textBoxRecherche;
        private Button buttonRecherche;
        private ProgressBar progressBar;
        private ComboBox comboBoxAlbums;
    }
}