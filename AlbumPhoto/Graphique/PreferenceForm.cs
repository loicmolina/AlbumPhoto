using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumPhoto
{
    public partial class PreferenceForm : Form
    {
        protected FolderBrowserDialog folderBrowserDialog;
        protected Donnees donnees;

        public PreferenceForm()
        {

            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        public PreferenceForm(Donnees dnn)
        {
            donnees = dnn;
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void button_browse_folder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                donnees.path_folder=folderBrowserDialog.SelectedPath;
                textBox_folder_path.Text = donnees.path_folder;
            }
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            if (!textBox_folder_path.Text.Equals(""))
            {
                this.Hide();

                //vide anciens albums
                donnees.cleanListeAlbums();

                //récupère dans le modèle les nouveaux albums
                string[] folders = System.IO.Directory.GetDirectories(donnees.path_folder, "*", System.IO.SearchOption.TopDirectoryOnly);
                donnees.UpdateAlbums(folders);

                foreach(string album in folders)
                {
                    Console.WriteLine(album);
                    DirectoryInfo dinfo = new DirectoryInfo(album);
                    FileInfo[] Files = dinfo.GetFiles();
                    donnees.UpdatePhotos(Files, donnees.GetAlbum(Outils.Outils.Instance.getName(album)));

                    

                }
                


                donnees.NotifyObservers();
            }
        }

    }
}
