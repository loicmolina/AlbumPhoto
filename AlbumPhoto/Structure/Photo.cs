using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto
{
    public class Photo
    {
        public string nom { get; set; }
        public List<string> tags { get; }

        public Photo(string nm)
        {
            nom = nm;
            tags = new List<string>();
        }

        public void AddTag(string tag)
        {
            tags.Add(tag);
        }

        public void ClearTags()
        {
            tags.Clear();
        }

        public void DisplayTags()
        {
           Console.WriteLine("Liste des tags pour l'image " + nom);
           foreach(string s in tags)
            {
                Console.WriteLine("-"+s);
            }
        }

        public int getSizeTags()
        {
            return tags.Count;
        }
        public override string ToString()
        {
            return nom;
        }

        public override bool Equals(object obj)
        {
            return nom.Equals(((Photo)obj).nom);
        }

        public override int GetHashCode()
        {
            var hashCode = 1733450653;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(tags);
            return hashCode;
        }
    }
}
