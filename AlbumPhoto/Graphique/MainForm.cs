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
        }

        public MainForm(Donnees dnn)
        {
            //association au modèle
            donnees = dnn;
            donnees.addObserver(this);

            //Initialisation des composants
            InitializeComponent();

            //Declaration des File et Browser Dialogs
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void button_import_image_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strng = folderBrowserDialog.SelectedPath;
                DirectoryInfo dinfo = new DirectoryInfo(strng);
                FileInfo[] files = dinfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Name.Contains(".png"))
                    {
                        imageList1.Images.Add(Image.FromFile(strng + "\\" + file.Name));
                        string s = imageList1.Images.Keys[0].ToString();
                        ListViewItem lstItem = new ListViewItem();
                        lstItem.ImageIndex = 0;
                        lstItem.Text = s;
                        listView1.Items.Add(lstItem);
                    }
                        
                }
            }
            /*if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }*/

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
            string[] folders = System.IO.Directory.GetDirectories(donnees.getPath(), "*", System.IO.SearchOption.TopDirectoryOnly).;
            foreach (string folder in folders)
            {
                listBox1.Items.Add(folder);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(donnees.getPath()+"/"+listBox1.SelectedItem.ToString());
            FileInfo[] Files = dinfo.GetFiles();
            foreach (FileInfo file in Files)
            {
                imageList1.Images.Add(Image.FromFile(donnees.getPath()+"/"+file.ToString()));
            }
        }
    }
}
