using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3D2_TemperatureLost
{
    public class Wall : IArea
    {
        public float ParamA { get; set; }
        public float ParamB { get; set; }
        
        public List<Material> Layers { get; set ; }
        Building buildinggg = new Building();
        public Wall()
        {

        }

        private float CalculateU()
        {
            float u = 1 / (Layers[0].GetR() + Layers[1].GetR() + Layers[2].GetR() + Layers[3].GetR());
            return u;
        }

        public virtual float CalculateArea()
        {
            return ParamA * ParamB;
        }

        

        public float CalculateDifT()
        {
            
            return buildinggg.InsideTempr - buildinggg.MinOutTempr;
            
        }

        public float CalculateQ()
        {
            float Q = CalculateU() * CalculateArea() * CalculateDifT();

           return Q;
        }
    }
}
