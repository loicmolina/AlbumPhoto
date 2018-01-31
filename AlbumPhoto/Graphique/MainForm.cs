using AlbumPhoto;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetAlbum
{
    public partial class MainForm : Form
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
            donnees = dnn;
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void button_import_image_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }

        }

        private void button_display_img_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0 || listBox1.SelectedIndex < 0)
            {
                return;
            }
            pictureBox1.Image = Image.FromFile(current_folder+"\\"+listBox1.SelectedItem.ToString());
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
    }
}
