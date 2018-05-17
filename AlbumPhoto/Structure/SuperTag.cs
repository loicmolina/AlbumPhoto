using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto.Structure
{
    public class SuperTag
    {
        public string nomSuperTag { get; set; }
        public List<string> ListeSousTags { get; }

        public SuperTag(string nom)
        {
            nomSuperTag = nom;
            ListeSousTags = new List<string>();
        }

        public void addTag(string tag)
        {
            if (!ListeSousTags.Contains(tag))
                ListeSousTags.Add(tag);
        }

        public void removeTag(string tag)
        {
            if (ListeSousTags.Contains(tag))
                ListeSousTags.Remove(tag);
        }

        public string getTag(int index)
        {
            if (index < ListeSousTags.Count)
                return ListeSousTags[index];
            else
                return "";
        }

        public bool containsTag(string tag)
        {
            return ListeSousTags.Contains(tag);
        }

        public override bool Equals(object obj)
        {
            return this.nomSuperTag.Equals(((SuperTag)obj).nomSuperTag);
        }

        public override int GetHashCode()
        {
            return 1727330060 + EqualityComparer<string>.Default.GetHashCode(nomSuperTag);
        }
    }
}
