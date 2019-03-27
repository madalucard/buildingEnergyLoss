using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3D2_TemperatureLost
{
    public class MaterialRepository
    {

        public Dictionary<string, float> _materialDatabase = new Dictionary<string, float>
        {
            {"", 1.00f},
            {"Beton", 1.30f},
            {"Omietka", 0.15f},
            {"Sadrokarton",0.22f},
            {"Ytong", 0.09f},
            {"Sklenna vata", 0.037f},
            {"Grafitovy polystyren", 0.031f},
        };

        public Dictionary<string, float> GetMeterials()
        {

            return _materialDatabase;
        }

        public IEnumerable<string> GetMeterialsKeys()
        {
           
            return _materialDatabase.Keys;
        }

        public Material CreateMaterial(string name, float thickness)
        {
            Material _mat = new Material();
            _mat.Name = name;
            _mat.Thickness = thickness;
            _mat.Lambda = _materialDatabase[name];
            

            return _mat;
        }
    }
}
