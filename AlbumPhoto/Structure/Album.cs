using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto
{
    public class Album
    {
        private List<Photo> listePhotos;

        public Album()
        {
            listePhotos = new List<Photo>();
        }

        public Photo getPhoto(int index)
        {
            return listePhotos[index];
        }

        public int getTailleAlbum()
        {
            return listePhotos.Count;
        }

        public void addPhoto(Photo p)
        {
            listePhotos.Add(p);
        }
    }
}
