using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumPhoto.Graphique
{
    public partial class DetailPhotoForm : Form
    {
        protected Photo currentPhoto;
        protected Image originalImage;
        protected Donnees donnees;

        public DetailPhotoForm(Photo photo,Donnees donnees)
        {
            InitializeComponent();
            this.currentPhoto = photo;
            this.donnees = donnees;
            this.labelPictureName.Text = photo.nom;
            
            image.Image = Image.FromFile(donnees.path_folder + "//" + donnees.current_album + "//"+photo.nom);
            originalImage = image.Image;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            if (trackBarZoom.Value > 0)
            {
                image.Image = Zoom(originalImage, new Size(trackBarZoom.Value, trackBarZoom.Value));
            }

        }

        private Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + 200, img.Height + 200);
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        private void DetailPhotoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (image.Image != null)            
                image.Dispose();
            if (originalImage != null)
                originalImage.Dispose();
        }

    }
}
