using AlbumPhoto.Obs;
using AlbumPhoto.Outils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AlbumPhoto
{
    public class Donnees
    {
        protected List<Observer> listeObservers;
        public List<Album> listeAlbums { get; }
        public List<string> listeLocalisations { get; }
        public List<string[]> listeResultats { get; }
        public String path_folder { get; set; }
        public Album current_album { get; set; }



        //Constucteur
        public Donnees()
        {
            listeObservers = new List<Observer>();
            listeAlbums = new List<Album>();
            listeLocalisations = new List<string>();
            listeResultats = new List<string[]>();
            path_folder = "";
        }

        //Vider les listes
        public void cleanListeAlbums()
        {
            listeAlbums.Clear();
        }


        //booléen permettant de vérifier les chemins définis
        public bool PathFolderIsEmpty() { return path_folder.Equals("") || path_folder == null; }

        public bool CurrentAlbumIsEmpty() { return current_album == null;  }
        


        //Gestion d'Observer/Observable

        public void AddObserver(Observer obs)
        {
            listeObservers.Add(obs);
        }

        public void NotifyObservers()
        {
            foreach (Observer o in listeObservers)
            {
                o.UpdateAlbumsField();
            }
        }
        

        //Méthodes de gestion des albums

        public void AddAlbum(Album album)
        {
            listeAlbums.Add(album);
        }

        public Album GetAlbum(string nom)
        {
            int i = 0;
            while(!listeAlbums[i].Equals(new Album(nom)))
            {
                i++;
            }
            return listeAlbums[i];
        }

        public void CreateAlbum(String name)
        {
            Directory.CreateDirectory(path_folder+ "\\"+name);
            int i = 0;
            while (i < listeAlbums.Count && string.Compare(name, listeAlbums[i].nom) > -1) //placement correct dans l'ordre alphabétique
            {
                i++;
            }
            listeAlbums.Insert(i, new Album(name));
        }

        public void DeleteAlbum(String name)
        {
            Directory.Delete(path_folder + "\\" + name, true);

            int i = 0;        
            while (!listeAlbums[i].Equals(name))  { i++; }

            listeAlbums.RemoveAt(i);
        }

        public void UpdateAlbums(string[] folders)
        {
            if (!listeLocalisations.Contains(path_folder))
            {
                listeLocalisations.Add(path_folder);
                foreach (string folder in folders)
                {
                    listeAlbums.Add(new Album(Outils.Outils.Instance.getName(folder)));
                }
            }
        }


        //Méthodes gestions photos

        public void UpdatePhotos(FileInfo[] Files)
        {
            foreach (FileInfo file in Files)
            {
                if (!current_album.containsPhoto(file.ToString()) && Outils.Outils.Instance.IsCorrectType(file.ToString()))
                    current_album.addPhoto(new Photo(file.ToString()));
            }
        }

        public Photo getPhoto(string nomAlbum, string nomPhoto)
        {
            return this.GetAlbum(nomAlbum).getPhoto(nomPhoto);
        }

        //Méthodes de recherches

        public void ChercherResultats(List<string> motscles)
        {
            listeResultats.Clear();
            current_album = null;

            foreach (Album a in listeAlbums)
            {
                foreach(Photo p in a.listePhotos)
                {
                    if (!motscles.Except(p.tags).Any() == true)
                    {
                        string[] res = new string[2];
                        res[0] = a.nom;
                        res[1] = p.nom;
                        listeResultats.Add(res);
                    }       
                }
            }
        }        
    }
}
