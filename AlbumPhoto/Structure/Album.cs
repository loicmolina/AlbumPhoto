using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto
{
    public class Album
    {
        public List<Photo> listePhotos { get; }
        public string nom { set; get; }

        public Album(string nom)
        {
            this.nom = nom;
            listePhotos = new List<Photo>();
        }

        public Album(List<Photo> listePhotos, string nom)
        {
            this.listePhotos = listePhotos;
            this.nom = nom;
        }

        public Photo getPhoto(int index)
        {
            return listePhotos[index];
        }

        public Photo getPhoto(string nom)
        {
            int index = getIndexPhoto(nom);
            Console.WriteLine("On reçoit " + index);
            return listePhotos[index];
        }

        public int getIndexPhoto(String nomRecherche)
        {
            if (listePhotos.Count == 0)
                return -1;
            Console.WriteLine("On cherche l'image : " + nomRecherche);
            Console.WriteLine("Nombre de photos dans l'album : " + listePhotos.Count);
            int i = 0;
            int res = -1;
            while (i < listePhotos.Count)
            {
                Console.WriteLine("i : " + i);
                Console.WriteLine("nom de l'image au rang i : " + listePhotos[i].nom);
                if (listePhotos[i].nom.Equals(nomRecherche))
                {
                    Console.WriteLine("trouvé");
                    res = i;
                    break;
                }
                i++;
            }
            Console.WriteLine("On renvoit "+res);
            return res;
        }

        public bool containsPhoto(string photoName)
        {
            bool contains = false;
            foreach (Photo photo in listePhotos)
            {
                if (photo.nom.Equals(photoName))
                {
                    contains = true;
                }
            }
            return contains;
        }

        public int getTailleAlbum()
        {
            return listePhotos.Count;
        }

        public void addPhoto(Photo p)
        {
            if (this.containsPhoto(p.nom))
                return;
            Console.WriteLine("AJOUT DE L'IMAGE DANS LE MODELE : " + p.nom);
            listePhotos.Add(p);            
        }

        public void addPhoto(Photo p, int index)
        {
            if (this.containsPhoto(p.nom))
                return;            
            listePhotos.Insert(index, p);            
        }

        public void delPhoto(string name, string path)
        {
            File.Delete(path+"//"+name);
            int i = 0;
            while (!listePhotos[i].Equals(name))
            {
                i++;
            }
            listePhotos.RemoveAt(i);
        }

        public override bool Equals(object obj)
        {
            return nom.Equals(((Album)obj).nom);
        }

        public override string ToString()
        {
            return nom;
        }

        public override int GetHashCode()
        {
            var hashCode = 1441943174;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Photo>>.Default.GetHashCode(listePhotos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
            return hashCode;
        }
    }
}
