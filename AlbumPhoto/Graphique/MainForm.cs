﻿using AlbumPhoto;
using AlbumPhoto.Obs;
using AlbumPhoto.Outils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetAlbum
{
    public partial class MainForm : Form, Observer
    {
        protected OpenFileDialog openFileDialog;
        protected FolderBrowserDialog folderBrowserDialog;
        protected PreferenceForm pf;
        protected Donnees donnees;       


        //Constructeurs
        public MainForm()
        {
            //Initialisation des composants
            InitializeComponent();
            listPictures.View = View.LargeIcon;
            listPictures.LargeImageList = listPhotos;

            //Instanciatons des File et Browser Dialogs
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();            
        }

        public MainForm(Donnees dnn)
        {
            //association au modèle
            donnees = dnn;
            donnees.AddObserver(this);

            //Initialisation des composants
            InitializeComponent();
            listPictures.View = View.LargeIcon;
            listPictures.LargeImageList = listPhotos;

            //Instanciatons des File et Browser Dialogs
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        //Gestion des boutons

        private void ButtonAddAlbum_Click(object sender, EventArgs e)
        {
            if (donnees.PathFolderIsEmpty() || donnees.listeAlbums.Contains(new Album(this.nameNewAlbum.Text)))
                return;
            donnees.CreateAlbum(this.nameNewAlbum.Text);
            UpdateAlbumsField();
        }


        private void ButtonAddPhoto_Click(object sender, EventArgs e)
        {
            if (donnees.CurrentAlbumIsEmpty() || donnees.PathFolderIsEmpty())
            { return; }

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.Copy(openFileDialog.FileName, donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(openFileDialog.FileName), true);
                listPhotos.Images.Add(Image.FromFile(donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(openFileDialog.FileName)));
                UpdateListPhotos();
            }
        }

        private void ButtonImportAlbum_Click(object sender, EventArgs e)
        {
            if (donnees.PathFolderIsEmpty())
            { return; }

            //à faire

        }

        private void ButtonDelImage_Click(object sender, EventArgs e)
        {
            if (listPictures.SelectedItems.Equals(null))
            { return; }

            ListView.SelectedIndexCollection indexes = listPictures.SelectedIndices;

            for (int i = indexes.Count - 1; i >= 0; i--)
            {
                listPhotos.Images.RemoveAt(indexes[i]);
            }

            buttonDelImage.Enabled = false;
            UpdateListPhotos();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Albums :");
            foreach (Album a in donnees.listeAlbums)
            {
                Console.WriteLine(a.nom);
            }if (!donnees.CurrentAlbumIsEmpty())
                Console.WriteLine("\n Album courant : " + donnees.current_album.ToString());

            Console.WriteLine("Liste des photos de l'album courant :");
            foreach(Photo p in donnees.current_album.listePhotos)
            {
                Console.WriteLine(p.nom);
            }
        }


        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LocalisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pf == null)
            {
                pf = new PreferenceForm(donnees);
            }            
            pf.Show();
        }



        //Gestions des Widgets à index 


        private void ListAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString());
            FileInfo[] Files = dinfo.GetFiles();
            donnees.current_album = donnees.listeAlbums[listAlbums.SelectedIndex];
            donnees.UpdatePhotos(Files);

            //vide les listes
            DisposeAll();

            foreach (FileInfo file in Files)
            {
                try
                {                    
                    listPhotos.Images.Add(Image.FromFile(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString() + "\\" + file.ToString()));
                }
                catch { }
                   
            }
            buttonImportPhoto.Enabled = true;
            UpdateListPhotos();
            
        }
        

        private void ListPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelImage.Enabled = true;
        }

        //Méthodes de mises à jour

        public void UpdateListPhotos()
        {
            listPictures.Clear();
            for (int j = 0; j < listPhotos.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listPictures.Items.Add(item);
            }
        }

       

        public void DisposeAll()
        {
            foreach (Image img in listPhotos.Images)
            {
                img.Dispose();
            }
            listPhotos.Images.Clear();
            listPictures.Items.Clear();
        }

        public void UpdateAlbumsField()
        {
            if (donnees.PathFolderIsEmpty())
                return;
            else
            {
                buttonNewAlbum.Enabled = true;
                buttonImportAlbum.Enabled = true;
            }

            //récupérations des albums dans le dossier
            string[] folders = System.IO.Directory.GetDirectories(donnees.path_folder, "*", System.IO.SearchOption.TopDirectoryOnly);

            //ajouts dans les listes
            donnees.UpdateAlbums(folders);

            //affichage
            listAlbums.Items.Clear();
            foreach (string folderpath in folders)
            {
                listAlbums.Items.Add(Outils.Instance.getName(folderpath));

            }
        }
    }
}
