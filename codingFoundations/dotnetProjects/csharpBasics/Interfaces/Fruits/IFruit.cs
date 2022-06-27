using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.Fruits
{
    public interface IFruit
    {
        // Interfaces don't use access modifiers (public/private/etc)
        string Name {get;} // Leave set for now, because then the implemented class would be required to have a set as well
        bool IsPeeled {get;}
        string Peel();
    }
}