using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetAlbum
{
    public partial class Form1 : Form
    {
        protected OpenFileDialog openFileDialog;
        protected FolderBrowserDialog folderBrowserDialog;
        protected string current_folder;

        public Form1()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

            }

        }

        private void button_import_album_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                current_folder = folderBrowserDialog.SelectedPath;
                DirectoryInfo dinfo = new DirectoryInfo(current_folder);
                FileInfo[] files = dinfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    listBox1.Items.Add(file.Name);
                }
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
    }
}
