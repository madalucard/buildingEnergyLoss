using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3D2_TemperatureLost
{
    interface IMaterial
    {
        int Id { get; set; }
        string Name { get; set; }
        float Lambda { get; set; }
        float Thickness { get; set; }
        //float R { get; set; }

        float GetR();
    }
}
