using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto.Outils
{
    class GestionDossiers
    {
        private static GestionDossiers instance;

        private GestionDossiers() { }

        public static GestionDossiers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GestionDossiers();
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
