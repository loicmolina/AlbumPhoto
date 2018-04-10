using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlbumPhoto.Outils
{
    class Outils
    {
        private static Outils instance;
        private Regex regex = new Regex("([^\\s]+(\\.(?i)(jpe?g))$)"); //A COMPLETER

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
                graphics.FillRectangle(Brushes.White, 0, 0, squareSize.Width, squareSize.Height);
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(originalImage, (squareSize.Width / 2) - (originalImage.Width / 2), (squareSize.Height / 2) - (originalImage.Height / 2), originalImage.Width, originalImage.Height);
            }
            return squareImage;
        }
    }
}
