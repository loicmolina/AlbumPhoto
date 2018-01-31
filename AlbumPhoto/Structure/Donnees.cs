using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto
{
    public class Donnees
    {
        protected List<Album> listeAlbums;
        protected string path_folder;

        public Donnees()
        {
            listeAlbums = new List<Album>();
            path_folder = "";
        }

        public string getPath()
        {
            return path_folder;
        }

        public void setPath(string s)
        {
            path_folder = s;
        }

        public void addAlbum(Album album)
        {
            listeAlbums.Add(album);
        }

        public Album getAlbum(int index)
        {
            return listeAlbums[index];
        }
    }
}
