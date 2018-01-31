using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto
{
    public class Photo
    {
        protected string nom { get; set; }
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
    }
}
