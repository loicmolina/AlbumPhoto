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
        protected Image img;

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

                img = Image.FromFile(openFileDialog.FileName);
                Bitmap btm = new Bitmap(img, new Size(400, 400));
                
                pictureBox1.Image = btm;

            }

        }

        private void button_import_album_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strng = folderBrowserDialog.SelectedPath;
                DirectoryInfo dinfo = new DirectoryInfo(strng);
                FileInfo[] files = dinfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    listBox1.Items.Add(file.Name);
                }
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                return;
            }

            int index = listBox1.IndexFromPoint(e.X, e.Y);
            string s = listBox1.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);
        }

        private void listBox1_DragLeave(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            lb.Items.Remove(lb.SelectedItem);
        }
        
    }
}
