using AlbumPhoto;
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
            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Selection d'image à importer";
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
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Selection d'image à importer";
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
                foreach (String filename in openFileDialog.FileNames)
                {
                    AjoutPhoto(filename);
                }
                RefreshImagesForm();
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
        }

        private void ButtonDelImage_Click(object sender, EventArgs e)
        {
            if (listPictures.SelectedItems.Equals(null))
            { return; }

            ListView.SelectedIndexCollection indexes = listPictures.SelectedIndices;
            for (int i = indexes.Count - 1; i >= 0; i--)
            {
                Console.WriteLine("Supression du fichier : " + donnees.path_folder + "\\" + donnees.current_album + "\\" + donnees.current_album.getPhoto(indexes[i]).nom);
                File.Delete(donnees.path_folder+"\\"+donnees.current_album+"\\"+donnees.current_album.getPhoto(indexes[i]).nom);

                Console.WriteLine("Supression dans la vue de la " + indexes[i]+ "eme image");
                listPhotos.Images.RemoveAt(indexes[i]);

                Console.WriteLine("Supression dans le modèle de : " + donnees.current_album.listePhotos[indexes[i]]);
                donnees.current_album.listePhotos.RemoveAt(indexes[i]);
            }

            buttonDelImage.Enabled = false;
            RefreshListView();
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
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString());
                FileInfo[] Files = dinfo.GetFiles();
                donnees.current_album = donnees.listeAlbums[listAlbums.SelectedIndex];
                donnees.UpdatePhotos(Files);

                RefreshImageList();             
                RefreshListView(); 

                buttonImportPhoto.Enabled = true;
            }
            catch{  }
                
        }
        

        private void ListPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelImage.Enabled = true;
        }



        //Methodes d'ajout des photos


        public void AjoutDansListePhotosForm(string img_fullname)
        {
            using(Image image = Image.FromFile(img_fullname))
            {
                //Console.WriteLine("AJOUT DE L'IMAGE DANS LA VUE : " + img_fullname);
                listPhotos.Images.Add(Outils.Instance.squareImage(image));                
            }  
        }

        public void AjoutPhoto(string filename)
        {
            if (donnees.current_album.containsPhoto(Outils.Instance.getName(filename)))
                return;

            Console.WriteLine("AJOUT LOLOL DE " + filename);
            

            if (Outils.Instance.IsCorrectType(filename))
            {
                System.IO.File.Copy(filename, donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(filename), true);
                AjoutDansListePhotosModele(Outils.Instance.getName(filename));
                AjoutDansListePhotosForm(donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(filename));
            }
        }
        
        public void AjoutDansListePhotosModele(string nom)
        {
            int i = 0;

            //Tant qu'on a pas atteint la fin de la liste ou que le mot de la liste se situe avant nom alphabétiquement
            while (i < donnees.current_album.listePhotos.Count && string.Compare(nom, donnees.current_album.listePhotos[i].nom) > -1)
            {
                i++;
            }
            //Console.WriteLine("AJOUT DE L'IMAGE DANS LE MODELE : " + nom);
            donnees.current_album.addPhoto(new Photo(nom), i);
        }


        //Méthodes de mises à jour

        public void RefreshImagesForm()
        {
            RefreshImageList();
            RefreshListView();
            //Console.WriteLine("REFRESHED !");
        }

        public void RefreshImageList()
        {
            DisposeAllPhotosForm();
            foreach (Photo p in donnees.current_album.listePhotos)
            {
                try
                {
                    if (Outils.Instance.IsCorrectType(p.nom))
                        AjoutDansListePhotosForm(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString() + "\\" + p.nom);
                }
                catch { }
            }
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
        }

        public void UpdateAlbumsField()
        {
            if (donnees.PathFolderIsEmpty())
                return;
            else
            {
                buttonNewAlbum.Enabled = true;
                buttonDelAlbum.Enabled = true;
            }

            //Console.WriteLine("Chemin des albums :" + donnees.path_folder);
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

        //Gestion du Drag&Drop

        private void listPictures_DragDrop(object sender, DragEventArgs e)
        {
            if (donnees.CurrentAlbumIsEmpty())
                return;
            string[] fileList = e.Data.GetData(DataFormats.FileDrop) as string[];
            
            foreach (string filename in fileList)
            {
                if (Outils.Instance.IsCorrectType(filename))
                    AjoutPhoto(filename);
            }
            RefreshImagesForm();
        }

        private void listPictures_DragEnter(object sender, DragEventArgs e)
        {
            if (donnees.CurrentAlbumIsEmpty())
                return;
            e.Effect = DragDropEffects.Copy;
        }

        private void listPictures_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listPictures.SelectedIndices.Count != 1 && listPhotos.Images.Count<=0)
                return;

            DetailPhotoForm dpf;
            if (listAlbums.SelectedIndex != -1)
            {
                dpf = new DetailPhotoForm(donnees.current_album, donnees.current_album.getPhoto(listPictures.SelectedIndices[0]), donnees);
            }
            else
            {
                Album album = donnees.GetAlbum( donnees.listeResultats[listPictures.SelectedIndices[0]][0] );

                Console.WriteLine(donnees.listeResultats[listPictures.SelectedIndices[0]][1]);

                Photo photo = donnees.getPhoto( album.nom , donnees.listeResultats[listPictures.SelectedIndices[0]][1] );


                Console.WriteLine("ALBUM :" +album.nom);
                Console.WriteLine("PHOTO :" +photo.nom);

                dpf = new DetailPhotoForm(album , photo, donnees);
            }

            Console.WriteLine("Ouverture de l'image numéro "+listPictures.SelectedIndices[0]);
            dpf.Show();
            
        }

        public void EffectuerRecherche()
        {
            if (textBoxRecherche.Text == "")
                return;

            List<string> ListeMotsCles = textBoxRecherche.Text.Split(',').ToList();
            donnees.ChercherResultats(ListeMotsCles);

            //Deselectionne Album
            listAlbums.SelectedIndex = -1;

            //Vide la liste de photos
            DisposeAllPhotosForm();

            //Ajoute les résultats de recherche
            foreach (string[] s in donnees.listeResultats)
            {
                AjoutDansListePhotosForm(donnees.path_folder + "//" + s[0] + "//" + s[1]);
            }
            RefreshListView();
        }

        private void buttonRecherche_Click(object sender, EventArgs e)
        {
            EffectuerRecherche();
        }

        private void textBoxRecherche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                EffectuerRecherche();
            }
        }
    }
}
