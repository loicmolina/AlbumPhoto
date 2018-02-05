using AlbumPhoto.Obs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AlbumPhoto
{
    public class Donnees
    {
        public List<Observer> listeObservers;
        protected List<Album> listeAlbums;
        protected String path_folder;

        public Donnees()
        {
            listeObservers = new List<Observer>();
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

        public void addObserver(Observer obs)
        {
            listeObservers.Add(obs);
        }

        public void addAlbum(Album album)
        {
            listeAlbums.Add(album);
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
