using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumPhoto.Obs
{
    public interface Observer
    {
        void UpdateAlbumsField();

        void DisposeAllPhotosForm();
    }
}
