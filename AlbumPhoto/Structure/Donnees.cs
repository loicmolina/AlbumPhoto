using AlbumPhoto.Obs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AlbumPhoto
{
    public class Donnees
    {
        public List<Observer> listeObservers;
        protected List<Album> listeAlbums;
        public String path_folder { get; set; }
        public String current_album { get; set; }

        public Donnees()
        {
            listeObservers = new List<Observer>();
            listeAlbums = new List<Album>();
            path_folder = "";
            current_album = "";
        }

        public bool path_folder_isEmpty() { return path_folder.Equals("") || path_folder.Equals(null); }

        public bool current_album_isEmpty() { return current_album.Equals("") || current_album.Equals(null);  }

        public void addObserver(Observer obs)
        {
            listeObservers.Add(obs);
        }

        public void addAlbum(Album album)
        {
            listeAlbums.Add(album);
        }

        public void createAlbum(String path, String name)
        {
            Directory.CreateDirectory(path+"\\"+name);
        }

        public Album getAlbum(int index)
        {
            return listeAlbums[index];
        }

        public void notifyObservers()
        {
            foreach (Observer o in listeObservers)
            {
                o.updateField();
            }
        }
        
    }
}
