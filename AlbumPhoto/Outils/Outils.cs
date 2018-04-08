using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto.Outils
{
    class Outils
    {
        private static Outils instance;

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
    }
}
