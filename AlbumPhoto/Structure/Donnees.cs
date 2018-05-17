using AlbumPhoto.Obs;
using AlbumPhoto.Outils;
using AlbumPhoto.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AlbumPhoto
{
    public class Donnees
    {
        protected List<Observer> listeObservers;
        public List<Album> listeAlbums { get; }
        public List<string[]> listeResultats { get; }
        public List<SuperTag> listeSuperTags { get; }
        public String path_folder { get; set; }
        public Album current_album { get; set; }



        //Constucteur
        public Donnees()
        {
            listeObservers = new List<Observer>();
            listeAlbums = new List<Album>();
            listeResultats = new List<string[]>();
            listeSuperTags = new List<SuperTag>();
            path_folder = "";
        }

        //Vider les listes
        public void cleanListeAlbums()
        {
            listeAlbums.Clear();
        }


        //booléen permettant de vérifier les chemins définis
        public bool PathFolderIsEmpty() { return path_folder.Equals("") || path_folder == null; }

        public bool CurrentAlbumIsEmpty() { return current_album == null; }



        //Gestion d'Observer/Observable

        public void AddObserver(Observer obs)
        {
            listeObservers.Add(obs);
        }

        public void NotifierVue()
        {
            foreach (Observer o in listeObservers)
            {
                o.DisposeAllPhotosForm();
                o.UpdateAlbumsField();
            }
        }

        //Methodes de gestion de la hiérarchie des tags
        public SuperTag getSuperTag(string nom)
        {
            int i = 0;
            while (i < listeSuperTags.Count - 1 && !listeSuperTags[0].nomSuperTag.Equals(nom))
                i++;
            if (listeSuperTags.Count > 0 && listeSuperTags[i].nomSuperTag.Equals(nom))
                return listeSuperTags[i];
            else
                return null;
        }

        public void addSuperTag(SuperTag st)
        {
            if(!listeSuperTags.Contains(st))
                listeSuperTags.Add(st);
        }


        //Méthodes de gestion des albums

        public void AddAlbum(Album album)
        {
            listeAlbums.Add(album);
        }

        public Album GetAlbum(string nom)
        {
            int i = 0;
            while (!listeAlbums[i].Equals(new Album(nom)))
            {
                i++;
            }
            return listeAlbums[i];
        }

        public void CreateAlbum(String name)
        {
            Directory.CreateDirectory(path_folder + "\\" + name);
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
            while (!listeAlbums[i].Equals(name)) { i++; }

            listeAlbums.RemoveAt(i);
        }

        public void UpdateAlbums(string[] folders)
        {
            foreach (string folder in folders)
            {
                Album album = new Album(Outils.Outils.Instance.getName(folder));
                if (!listeAlbums.Contains(album))
                {
                    listeAlbums.Add(album);
                }
            }
        }

        //Méthodes gestions photos

        public void UpdatePhotos(FileInfo[] Files,Album album)
        {
            foreach (FileInfo file in Files)
            {
                if (!album.containsPhoto(file.ToString()) && Outils.Outils.Instance.IsCorrectType(file.ToString()))
                {
                    Photo p = new Photo(file.ToString());
                    album.addPhoto(p);
                    UpdateTags(file.FullName, p);
                }
            }
        }

        public Photo getPhoto(string nomAlbum, string nomPhoto)
        {
            return this.GetAlbum(nomAlbum).getPhoto(nomPhoto);
        }


        //Méthodes gestions tags
        public void UpdateTags(string filename, Photo p)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(filename)))
                {
                    using (Image img = Image.FromStream(ms))
                    {
                        PropertyItem pi = Outils.Outils.Instance.getPropertyItemByID(img, 40094);  //40094 = id des tags        
                        if (pi != null)
                        {
                            List<string> listeTags = System.Text.Encoding.Unicode.GetString(pi.Value).Split(';').ToList();
                            p.ClearTags();
                            for (int i = 0; i < listeTags.Count; i++)
                            {
                                if (listeTags[i].Trim() != "" && listeTags[i].Trim() != "\n")
                                {
                                    if (i == listeTags.Count - 1)
                                        p.AddTag(listeTags[i].Remove(listeTags[i].Length - 1));
                                    else
                                        p.AddTag(listeTags[i]);
                                    Console.WriteLine("ajout du tag  :" + p.tags[i]);
                                }
                                
                            }
                        }
                        else
                        {
                            var newProp = (PropertyItem)Activator.CreateInstance(typeof(PropertyItem), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[0], CultureInfo.InvariantCulture);
                            newProp.Id = 0x9c9e;
                            newProp.Type = 1;
                            newProp.Value = Encoding.Unicode.GetBytes("/0");
                            newProp.Len = newProp.Value.Length;
                            img.SetPropertyItem(newProp);
                        }
                    }
                }
            }
            catch { }
            
        }


        //Méthodes de recherches

        public void ChercherResultats(List<string> motscles, string domaine, string zone)
        {

            listeResultats.Clear();
            current_album = null;

            List<string> newtags = new List<string>();
            
            foreach (SuperTag st in listeSuperTags)
            {
                if (motscles.Contains(st.nomSuperTag))
                {
                    newtags.AddRange(st.ListeSousTags);
                }
            }

            newtags.AddRange(motscles);

            if (domaine.Equals("Tous"))
            {
                foreach (Album album in listeAlbums)
                {
                    foreach (Photo photo in album.listePhotos)
                    {
                        if (verification(photo, newtags, zone))
                        {
                            string[] res = new string[2];
                            res[0] = album.nom;
                            res[1] = photo.nom;
                            listeResultats.Add(res);
                        }
                    }
                }
            }
            else
            {
                Album album = this.GetAlbum(domaine);
                foreach (Photo photo in album.listePhotos)
                {
                    if (verification(photo,newtags,zone))
                    {
                        string[] res = new string[2];
                        res[0] = album.nom;
                        res[1] = photo.nom;
                        listeResultats.Add(res);
                    }
                }
            }
            
        }  
        
        public bool verification(Photo p,List<string> tags,string zone)
        {
            if (zone.Equals("Union")){
                return p.tags.Any(x => tags.Contains(x)) == true;
            }
            else
            {
                return !tags.Except(p.tags).Any() == true;
            }

        }
    }
}
