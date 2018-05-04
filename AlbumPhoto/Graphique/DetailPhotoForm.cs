using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
        protected PropertyItem pi;

        public DetailPhotoForm(Album album, Photo photo,Donnees donnees)
        {
            InitializeComponent();
            this.currentPhoto = photo;
            this.donnees = donnees;
            this.labelPictureName.Text = photo.nom;
            this.labelAlbumName.Text = album.nom;
            
            using(Image img = Image.FromFile(donnees.path_folder + "//" + album.nom + "//" + photo.nom))
            {
                image.Image = Outils.Outils.Instance.copyImage(img) ;
                foreach(PropertyItem prop in img.PropertyItems)
                {
                    image.Image.SetPropertyItem(prop);
                }

                pi = Outils.Outils.Instance.getPropertyItemByID(img,40094);  //40094 = id des tags                

                if (pi != null)
                {
                    foreach (string s in currentPhoto.tags)
                    {
                        this.textBoxTags.Text += s + Environment.NewLine;
                    }
                }
                else
                {
                    var newProp = (PropertyItem)Activator.CreateInstance(typeof(PropertyItem), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[0], CultureInfo.InvariantCulture);
                    newProp.Id = 0x9c9e;
                    newProp.Type = 1;
                    newProp.Value = Encoding.Unicode.GetBytes("/0");
                    newProp.Len = newProp.Value.Length;
                    image.Image.SetPropertyItem(newProp);
                    pi = Outils.Outils.Instance.getPropertyItemByID(image.Image, 40094);  //40094 = id des tags    */            

                }
            }           
        }


        private void registerButton_Click(object sender, EventArgs e)
        {            
            this.currentPhoto.ClearTags();
            string[] tagsRegistered = textBoxTags.Text.Replace(Environment.NewLine,"\n").Split('\n') ;
            string value = "";
            foreach(string s in tagsRegistered)
            {
                value += s + ';';
            }
            
            image.Image.RemovePropertyItem(40094); //Suppression des anciens tags
            pi.Value = Encoding.Unicode.GetBytes(value+"\0");

            image.Image.SetPropertyItem(pi);
            image.Image.Save(donnees.path_folder + "//" + labelAlbumName.Text + "//" +labelPictureName.Text,ImageFormat.Jpeg);

            foreach (string s in tagsRegistered)
            {
                this.currentPhoto.AddTag(s.Trim());                
            }

            this.Close();
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
            Bitmap bmp = new Bitmap(img, img.Width + 200 + 200/size.Width, img.Height + 200 + 200 / size.Height);
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
