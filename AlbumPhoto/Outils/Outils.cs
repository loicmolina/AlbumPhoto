using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlbumPhoto.Outils
{
    class Outils
    {
        private static Outils instance;
        private Regex regex = new Regex("([^\\s]+(\\.(?i)(jpe?g))$)");

        private Outils() { }

        public static Outils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Outils();
                }
                return instance;
            }
        }

        //retourne un booleen selon le type du fichier (JPEG ou non)
        public bool IsCorrectType(string filename) {
            return regex.IsMatch(filename);
        }

        //retourne le nom du fichier/dossier en supprimant le path
        public string getName(string absolutePath)
        {
            int i = absolutePath.Length - 1;
            while (!absolutePath[i].Equals('\\') || i == 0)
            {
                i--;
            }
            i++;
            return absolutePath.Substring(i, absolutePath.Length - i);
        }

        //converti l'image dans un carré
        public Image squareImage(Image originalImage)
        {
            if (originalImage.Height == originalImage.Width)
                return originalImage;
            int largestDimension = Math.Max(originalImage.Height, originalImage.Width);
            Size squareSize = new Size(largestDimension, largestDimension);
            Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
            using (Graphics graphics = Graphics.FromImage(squareImage))
            {
                graphics.DrawImage(originalImage, (squareSize.Width / 2) - (originalImage.Width / 2), (squareSize.Height / 2) - (originalImage.Height / 2), originalImage.Width, originalImage.Height);
            }
            return squareImage;
        }

        //Copie image
        public Image copyImage(Image originalImage)
        {
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(originalImage, new Rectangle(0, 0, newImage.Width, newImage.Height));
            }
            return newImage;
        }

        //Supprime les espaces d'une liste
        public void TrimList(List<string> liste)
        {
            for(int i = 0; i< liste.Count; i++)
            {
                liste[i] = liste[i].Trim();
            }   
        }

        //
        public PropertyItem getPropertyItemByID(Image img, int Id)
        {
            return img.PropertyItems.Select(x => x).FirstOrDefault(x => x.Id == Id);
        }
    }
}
