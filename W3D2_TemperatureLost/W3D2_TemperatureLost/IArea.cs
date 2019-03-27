using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3D2_TemperatureLost
{
    public interface IArea
    {
        float ParamA { get; set; }
        float ParamB { get; set; }
        
        List<Material> Layers { get; set; }

        float CalculateArea();
        float CalculateQ();
        float CalculateDifT();
        

        
    }
}
