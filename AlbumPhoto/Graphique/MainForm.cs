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
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = listePhotos;
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

            //Declaration des File et Browser Dialogs
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void button_display_img_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0 || listBox1.SelectedIndex < 0)
            {
                return;
            }
            //pictureBox1.Image = Image.FromFile(current_folder+"\\"+listBox1.SelectedItem.ToString());
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
            string[] folders = System.IO.Directory.GetDirectories(donnees.getPath(), "*", System.IO.SearchOption.TopDirectoryOnly);
            listBox1.Items.Clear();
            foreach (string folder in folders)
            {
                listBox1.Items.Add(folderName(folder));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(donnees.getPath()+"\\"+listBox1.SelectedItem.ToString());
            FileInfo[] Files = dinfo.GetFiles();

            //vide les listes
            disposeAll();

            foreach (FileInfo file in Files)
            {
                try
                {
                    listePhotos.Images.Add(Image.FromFile(donnees.getPath() + "\\" + listBox1.SelectedItem.ToString() + "\\" + file.ToString()));
                }
                catch { Console.WriteLine("Image introuvable"); }
                   
            }


            for (int j = 0; j < listePhotos.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(item);
            }
        }

        public string folderName(string absolutePath)
        {
            int i = absolutePath.Length-1;
            while (!absolutePath[i].Equals('\\'))
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
    }
}
