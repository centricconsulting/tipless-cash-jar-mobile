using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiplessCashJar
{
    public interface ILocation
    {
        void ObtainLocation();
        event EventHandler<ILocationEventArgs> LocationObtained;
    }

    public interface ILocationEventArgs
    {
        double lat { get; set; }
        double lng { get; set; }
    }
}
