using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface Observable
    {
        void RegisterObserver(Observer observer);
        void NotifyObservers();
    }
}
