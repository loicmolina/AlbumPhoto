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
        protected List<string> tags;

        public Photo(string nm)
        {
            nom = nm;
            tags = new List<string>();
        }

        public void addTag(string tag)
        {
            tags.Add(tag);
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
