using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3D2_TemperatureLost

{
    public class Building
    {
        public string BuildingName { get; set; }
        public string FirstNameAuth { get; set; }
        public string LastNanemAuth { get; set; }
        public bool IsWindy { get; set; }
        public bool IsProtectedWell { get; set; }
        public bool IsProtectedBad { get; set; }

        public float Windy { get { return _windy; } }
        private const float _windy= 1.03f;
        public float ProtectionAverage { get { return _protectionAverage; } }
        private const float _protectionAverage = 1.03f;
        public float ProtectionBad { get { return _protectionBad; } }
        private const float _protectionBad = 1.06f;
        public float MinOutTempr { get { return _minOutTempr; } }
        private const float _minOutTempr = -16.00f;
        public float InsideTempr { get { return _insideTempr; } }
        private const float _insideTempr = 21.00f;

        public Building()
        {
                        
        }
    }
}
