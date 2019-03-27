using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3D2_TemperatureLost
{
    public class Material : IMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Lambda { get; set; }
        public float Thickness { get; set; }
        public float _r;

        
        public float GetR()
        {
            _r = Thickness / Lambda;
            return _r;
        }

    }
}
