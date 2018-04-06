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
        private List<Photo> listePhotos;
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

        public int getTailleAlbum()
        {
            return listePhotos.Count;
        }

        public void addPhoto(string nom)
        {
            listePhotos.Add(new Photo(nom));
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
