using AlbumPhoto;
using AlbumPhoto.Obs;
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
       
        protected string current_folder;

        public MainForm()
        {
            //Initialisation des composants
            InitializeComponent();
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = listePhotos;

            //Instanciatons des File et Browser Dialogs
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();            
        }

        public MainForm(Donnees dnn)
        {
            //association au modèle
            donnees = dnn;
            donnees.addObserver(this);

            //Initialisation des composants
            InitializeComponent();
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = listePhotos;

            //Instanciatons des File et Browser Dialogs
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void button_AddAlbum(object sender, EventArgs e)
        {
            if (donnees.path_folder_isEmpty())
                return;
            donnees.createAlbum(donnees.path_folder, this.nameNewAlbum.Text);
            updateField();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void localisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pf == null)
            {
                pf = new PreferenceForm(donnees);
            }            
            pf.Show();
        }

        public void updateField()
        {
            if (donnees.path_folder_isEmpty())
                return;
            string[] folders = System.IO.Directory.GetDirectories(donnees.path_folder, "*", System.IO.SearchOption.TopDirectoryOnly);
            listAlbums.Items.Clear();
            foreach (string folderpath in folders)
            {
                listAlbums.Items.Add(getName(folderpath));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(donnees.path_folder + "\\"+listAlbums.SelectedItem.ToString());
            FileInfo[] Files = dinfo.GetFiles();
            donnees.current_album = listAlbums.SelectedItem.ToString();

            //vide les listes
            disposeAll();

            foreach (FileInfo file in Files)
            {
                try
                {                    
                    listePhotos.Images.Add(Image.FromFile(donnees.path_folder + "\\" + listAlbums.SelectedItem.ToString() + "\\" + file.ToString()));
                }
                catch { Console.WriteLine("Image introuvable"); }
                   
            }

            redrawListPhotos();
            
        }

        public void redrawListPhotos()
        {
            listView1.Clear();
            for (int j = 0; j < listePhotos.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(item);
            }
        }

        public string getName(string absolutePath)
        {
            int i = absolutePath.Length-1;
            while (!absolutePath[i].Equals('\\') || i==0)
            {
                i--;
            }
            i++;
            return absolutePath.Substring(i, absolutePath.Length - i);
        }

        public void disposeAll()
        {
            foreach (Image img in listePhotos.Images)
            {
                img.Dispose();
            }
            listePhotos.Images.Clear();
            listView1.Items.Clear();
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            if ( donnees.current_album_isEmpty() || donnees.path_folder_isEmpty() )
                { return; }

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.Copy(openFileDialog.FileName, donnees.path_folder + "\\" + donnees.current_album + "\\" + getName(openFileDialog.FileName));
                listePhotos.Images.Add(Image.FromFile(donnees.path_folder + "\\" + donnees.current_album + "\\" + getName(openFileDialog.FileName)));
                redrawListPhotos();
            }
        }

        private void buttonImportAlbum_Click(object sender, EventArgs e)
        {
            if (donnees.path_folder_isEmpty())
            { return; }


        }
    }
}
