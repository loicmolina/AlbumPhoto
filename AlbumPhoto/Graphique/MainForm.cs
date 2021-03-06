﻿using AlbumPhoto;
using AlbumPhoto.Graphique;
using AlbumPhoto.Obs;
using AlbumPhoto.Outils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetAlbum
{
    public partial class MainForm : Form, Observer
    {
        protected OpenFileDialog openFileDialog;
        protected SuperTagsForm stf;
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
            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Filter = "Image files | *.jpg; *.jpeg;";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Selection d'image à importer";      
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
            this.openFileDialog.Filter = "Image files | *.jpg; *.jpeg;";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Selection d'image à importer";
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
                foreach (String filename in openFileDialog.FileNames)
                {
                    AjoutPhoto(filename);
                }
                //RefreshListView();
            }
        }

        private void ButtonDelAlbum_Click(object sender, EventArgs e)
        {
            if (donnees.PathFolderIsEmpty() || donnees.CurrentAlbumIsEmpty())
                { return; }

            
            Directory.Delete(donnees.path_folder + "\\" + listAlbums.Items[listAlbums.SelectedIndex], true); //suppression dans les fichiers

            donnees.listeAlbums[listAlbums.SelectedIndex].listePhotos.Clear(); //vide l'album de ses photos (Modèle)
            donnees.listeAlbums.RemoveAt(listAlbums.SelectedIndex); //supression de l'album dans la liste (Modèle)

            DisposeAllPhotosForm(); //suppression des photos (Form)
            listAlbums.Items.RemoveAt(listAlbums.SelectedIndex); //suppression de l'album de la liste (Form)
            
            UpdateAlbumsField();

            if (listAlbums.SelectedIndex == -1)
            {
                buttonDelPhoto.Enabled = false;
                buttonImportPhoto.Enabled = false;
                buttonDelAlbum.Enabled = false;
            }
        }

        private void ButtonDelImage_Click(object sender, EventArgs e)
        {
            SupprimerPhoto();
        }

        private void ButtonRecherche_Click(object sender, EventArgs e)
        {
            buttonDelAlbum.Enabled = true;
            EffectuerRecherche();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            if (listAlbums != null)
            {
                Console.WriteLine("Albums :");
                foreach (Album a in donnees.listeAlbums)
                {
                    Console.WriteLine(a.nom);
                }
                if (!donnees.CurrentAlbumIsEmpty())
                    Console.WriteLine("\n Album courant : " + donnees.current_album.ToString());
            }     
            if (donnees.current_album != null)
            {
                Console.WriteLine("Liste des photos de l'album courant :");
                foreach (Photo p in donnees.current_album.listePhotos)
                {
                    if (Outils.Instance.IsCorrectType(p.nom))
                        Console.WriteLine(p.nom);
                }
            }
            Console.WriteLine("affichae domaine :" + comboBoxAlbums.SelectedValue);
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LocalisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pf != null)
            {
                pf.Dispose();
            }

            pf = new PreferenceForm(donnees);                    
            pf.Show();
        }


        private void gestionDesSuperTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stf != null)
            {
                stf.Dispose();
            }
            stf = new SuperTagsForm(donnees);
            stf.Show();
        }

        //Gestions des Widgets à index 


        private void ListAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelAlbum.Enabled = true;
            if (donnees.current_album != null && donnees.current_album.nom.Equals(listAlbums.SelectedItem))    {  return;  }


            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString());
                FileInfo[] Files = dinfo.GetFiles();
                donnees.current_album = donnees.listeAlbums[listAlbums.SelectedIndex];
                donnees.UpdatePhotos(Files, donnees.current_album);

                RefreshImageList();             
                RefreshListView(); 

                buttonImportPhoto.Enabled = true;
            }
            catch{  }
                
        }
        

        private void ListPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (donnees.current_album != null)
                buttonDelPhoto.Enabled = true;
            else
                buttonDelPhoto.Enabled = false;
        }



        //Methodes d'ajout des photos


        public void AjoutDansListePhotosForm(string img_fullname, bool newphoto)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(img_fullname)))
                {
                    using (Image image = Image.FromStream(ms))
                    {

                        //Console.WriteLine("AJOUT DE L'IMAGE DANS LA VUE : " + img_fullname);
                        ListViewItem newItem = new ListViewItem();
                        newItem.ImageIndex = listPhotos.Images.Count;
                        listPictures.Items.Add(newItem);
                        listPhotos.Images.Add(Outils.Instance.getName(img_fullname), Outils.Instance.squareImage(image));

                    }
                }
            }
            catch { if (newphoto) { MessageBox.Show("Fichier inutilisable (Format incorrect ou données corrompus"); }  }
            
        }

        public void AjoutPhoto(string filename)
        {
            if (donnees.current_album.containsPhoto(Outils.Instance.getName(filename)))
                return;

            if (Outils.Instance.IsCorrectType(filename))
            {
                System.IO.File.Copy(filename, donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(filename), true);
                AjoutDansListePhotosModele(Outils.Instance.getName(filename));
                AjoutDansListePhotosForm(donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(filename),true);
            }
        }
        
        public void AjoutDansListePhotosModele(string nom)
        {
            int i = 0;
            
            //Console.WriteLine("AJOUT DE L'IMAGE DANS LE MODELE : " + nom);
            donnees.current_album.addPhoto(new Photo(nom));
            donnees.UpdateTags(donnees.path_folder + "//" + donnees.current_album.nom + "//" + nom, donnees.current_album.listePhotos[i]);
        }


        //Méthodes de suppression de photos


        public void SupprimerPhoto()
        {
            if (listPictures.SelectedItems.Equals(null) || listAlbums.SelectedIndex == -1)
            { return; }

            DialogResult dr = MessageBox.Show("Êtes-vous certain de vouloir supprimer ce(s) élément(s) ?","Supression",MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                ListView.SelectedIndexCollection indexes = listPictures.SelectedIndices;
                for (int i = indexes.Count - 1; i >= 0; i--)
                {
                    //Console.WriteLine("Supression du fichier : " + donnees.path_folder + "\\" + donnees.current_album + "\\" + donnees.current_album.getPhoto(indexes[i]).nom);
                    File.Delete(donnees.path_folder + "\\" + donnees.current_album + "\\" + donnees.current_album.getPhoto(listPhotos.Images.Keys[indexes[i]]).nom);

                    //Console.WriteLine("Supression dans le modèle de : " + donnees.current_album.listePhotos[indexes[i]]);
                    donnees.current_album.delPhoto(listPhotos.Images.Keys[indexes[i]]);

                    //Console.WriteLine("Supression dans la vue de la " + indexes[i]+ "eme image");
                    listPhotos.Images.RemoveAt(indexes[i]);
                    listPictures.Items.RemoveAt(listPictures.Items.Count - 1);

                }
                listPictures.SelectedIndices.Clear();
                buttonDelPhoto.Enabled = false;
            }

        }




        //Méthodes de mises à jour

        public void RefreshImageList()
        {
            DisposeAllPhotosForm();

            progressBar.Maximum = donnees.current_album.listePhotos.Count;
            progressBar.Value = progressBar.Minimum;
            foreach (Photo p in donnees.current_album.listePhotos)
            {
                try
                {
                    if (Outils.Instance.IsCorrectType(p.nom))
                    {
                        AjoutDansListePhotosForm(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString() + "\\" + p.nom,false);
                        progressBar.Value += 1;
                    }
                }
                catch { }
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void RefreshListView()
        {
            listPictures.Clear();
            for (int j = 0; j < listPhotos.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listPictures.Items.Add(item);
            }
        }

        public void DisposeAllPhotosForm()
        {
            foreach (Image img in listPhotos.Images)
            {
                img.Dispose();
            }
            listPhotos.Images.Clear();
            listPictures.Clear();
            listPictures.Items.Clear();
            GC.Collect();
        }

        public void UpdateAlbumsField()
        {
            if (donnees.PathFolderIsEmpty())
                return;
            else
            {
                buttonNewAlbum.Enabled = true;
            }

            //Console.WriteLine("Chemin des albums :" + donnees.path_folder);
            //récupérations des albums dans le dossier
            string[] folders = System.IO.Directory.GetDirectories(donnees.path_folder, "*", System.IO.SearchOption.TopDirectoryOnly);

            //ajouts dans les listes
            donnees.UpdateAlbums(folders);

            //affichage
            listAlbums.Items.Clear();
            comboBoxAlbums.Items.Clear();
            comboBoxAlbums.Items.Add("Tous");
            comboBoxAlbums.SelectedIndex = 0;
            comboBoxZone.SelectedIndex = 0;

            foreach (string folderpath in folders)
            {
                string album = Outils.Instance.getName(folderpath);
                listAlbums.Items.Add(album);
                comboBoxAlbums.Items.Add(album);                
            }
            
        }

        //Gestion du Drag&Drop

        private void ListPictures_DragDrop(object sender, DragEventArgs e)
        {
            if (donnees.CurrentAlbumIsEmpty())
                return;
            string[] fileList = e.Data.GetData(DataFormats.FileDrop) as string[];
            
            foreach (string filename in fileList)
            {
                AjoutPhoto(filename);
            }

        }

        private void ListPictures_DragEnter(object sender, DragEventArgs e)
        {
            if (donnees.CurrentAlbumIsEmpty())
                return;
            e.Effect = DragDropEffects.Copy;
        }


        //Detail des images


        private void ListPictures_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listPictures.SelectedIndices.Count != 1 && listPhotos.Images.Count<=0)
                return;

            DetailPhotoForm dpf;
            if (listAlbums.SelectedIndex != -1)
            {
                dpf = new DetailPhotoForm(donnees.current_album, donnees.current_album.getPhoto( listPhotos.Images.Keys[listPictures.SelectedIndices[0]] ), donnees);
                dpf.Show();
            }
            else
            {
                try
                {
                    Album album = donnees.GetAlbum(donnees.listeResultats[listPictures.SelectedIndices[0]][0]);
                    Photo photo = donnees.getPhoto(album.nom, donnees.listeResultats[listPictures.SelectedIndices[0]][1]);
                    dpf = new DetailPhotoForm(album, photo, donnees);
                    dpf.Show();
                }
                catch { } 
            }
            
        }


        //Gestion des recherches et tags 


        public void EffectuerRecherche()
        {
            if (textBoxRecherche.Text.Trim() == "" || comboBoxAlbums.Text=="")
                return;

            buttonImportPhoto.Enabled = false;
            buttonDelPhoto.Enabled = false;
            buttonDelAlbum.Enabled = false;

            List<string> ListeMotsCles = textBoxRecherche.Text.Split(',').ToList();
            Outils.Instance.TrimList(ListeMotsCles);
            
            donnees.ChercherResultats(ListeMotsCles, comboBoxAlbums.Text, comboBoxZone.Text);

            //Deselectionne Album
            listAlbums.SelectedIndex = -1;

            //Vide la liste de photos
            DisposeAllPhotosForm();

            //Ajoute les résultats de recherche
            foreach (string[] s in donnees.listeResultats)
            {
                AjoutDansListePhotosForm(donnees.path_folder + "//" + s[0] + "//" + s[1],false);
            }
        }


        //raccourcis clavier

        private void TextBoxRecherche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                EffectuerRecherche();
            }
        }


        private void listPictures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                SupprimerPhoto();
            }
        }

    }
}
