using AlbumPhoto;
using AlbumPhoto.Graphique;
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
                    if (Outils.Instance.IsCorrectType(Outils.Instance.getName(filename)))
                    {
                        AjoutPhoto(filename);                     
                    }
                }
                UpdateListPhotos();
            }
        }

        private void ButtonDelAlbum_Click(object sender, EventArgs e)
        {
            if (donnees.PathFolderIsEmpty() || donnees.CurrentAlbumIsEmpty())
                { return; }
            Directory.Delete(donnees.path_folder + "\\" + listAlbums.Items[ listAlbums.SelectedIndex ], true);
            listAlbums.Items.RemoveAt( listAlbums.SelectedIndices[ listAlbums.SelectedIndex ] );       
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
                if (Outils.Instance.IsCorrectType(p.nom))
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
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString());
                FileInfo[] Files = dinfo.GetFiles();
                donnees.current_album = donnees.listeAlbums[listAlbums.SelectedIndex];
                donnees.UpdatePhotos(Files);

                DisposeAll();

                foreach (FileInfo file in Files)
                {
                    try
                    {
                        if (Outils.Instance.IsCorrectType(file.Name))
                            AjoutDansListePhotosForm(Image.FromFile(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString() + "\\" + file.ToString()));
                    }
                    catch { }

                }
                buttonImportPhoto.Enabled = true;
                UpdateListPhotos();
            }
            catch{  }
                
        }
        

        private void ListPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelImage.Enabled = true;
        }


        //Methodes d'ajout des photos

        public void AjoutDansListePhotosForm(Image img)
        {
            listPhotos.Images.Add(Outils.Instance.squareImage(img));
        }

        public void AjoutPhoto(string filename)
        {            
            System.IO.File.Copy(filename, donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(filename), true);
            AjoutDansListePhotosForm(Image.FromFile(donnees.path_folder + "\\" + donnees.current_album + "\\" + Outils.Instance.getName(filename)));
            AjoutDansListePhotosModele(Outils.Instance.getName(filename));
        }
        
        public void AjoutDansListePhotosModele(string nom)
        {
            int i = 0;

            //Tant qu'on a pas atteint la fin de la liste ou que le mot de la liste se situe avant nom alphabétiquement
            while (i < donnees.current_album.listePhotos.Count && string.Compare(nom, donnees.current_album.listePhotos[i].nom) > -1)
            {
                i++;
            }
            donnees.current_album.addPhoto(new Photo(nom), i);
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

        //vide les listes
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
                buttonDelAlbum.Enabled = true;
            }

            Console.WriteLine(donnees.path_folder);
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
            UpdateListPhotos();
        }

        private void listPictures_DragEnter(object sender, DragEventArgs e)
        {
            if (donnees.CurrentAlbumIsEmpty())
                return;
            e.Effect = DragDropEffects.Copy;
        }

        private void listPictures_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listPictures.SelectedIndices.Count == 0 || listPictures.SelectedIndices.Count > 1)
                return;
            DetailPhotoForm dpf = new DetailPhotoForm(donnees.current_album.getPhoto( listPictures.SelectedIndices[0] ), donnees);
            dpf.Show();
        }
    }
}
