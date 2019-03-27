using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3D2_TemperatureLost
{
    public class ViewModel
    {
        #region building fields
        public string BuildingName { get; set; }
        public string FirstNameAuth { get; set; }
        public string LastNanemAuth { get; set; }
        public bool IsWindy { get; set; }
        public bool IsProtectedBad { get; set; }
        public bool IsProtectedAverage { get; set; }
        public float CircuitOfHouse { get; set; }
        public float HeightOfHouse { get; set; }
        #endregion
        #region walls fields
        public float SizeA { get; set; }
        public float SizeB { get; set; }
        public float HeightOfWall { get; set; }
        #endregion
        #region materials fields
        public float WallsThicknessLayer1 { get; set; }
        public float WallsThicknessLayer2 { get; set; }
        public float WallsThicknessLayer3 { get; set; }
        public float WallsThicknessLayer4 { get; set; }

        public float RoofThicknessLayer1 { get; set; }
        public float RoofThicknessLayer2 { get; set; }
        public float RoofThicknessLayer3 { get; set; }
        public float RoofThicknessLayer4 { get; set; }

        public float FloorThicknessLayer1 { get; set; }
        public float FloorThicknessLayer2 { get; set; }
        public float FloorThicknessLayer3 { get; set; }
        public float FloorThicknessLayer4 { get; set; }

        public string WallMaterialLayer1 { get; set; }
        public string WallMaterialLayer2 { get; set; }
        public string WallMaterialLayer3 { get; set; }
        public string WallMaterialLayer4 { get; set; }

        public string RoofMaterialLayer1 { get; set; }
        public string RoofMaterialLayer2 { get; set; }
        public string RoofMaterialLayer3 { get; set; }
        public string RoofMaterialLayer4 { get; set; }

        public string FloorMaterialLayer1 { get; set; }
        public string FloorMaterialLayer2 { get; set; }
        public string FloorMaterialLayer3 { get; set; }
        public string FloorMaterialLayer4 { get; set; }
        #endregion
        

        private MaterialRepository _matRep;
        public ViewModel()
        {
            _matRep = new MaterialRepository();
        }

        public IEnumerable<string> GetMeterialsKeys()
        {
            return _matRep.GetMeterialsKeys();
        }

        private List<Material> Roofmaterial()
        {
            List<Material> list= new List<Material>();
            list.Add(_matRep.CreateMaterial(RoofMaterialLayer1, RoofThicknessLayer1));
            list.Add(_matRep.CreateMaterial(RoofMaterialLayer2, RoofThicknessLayer2));
            list.Add(_matRep.CreateMaterial(RoofMaterialLayer3, RoofThicknessLayer3));
            list.Add(_matRep.CreateMaterial(RoofMaterialLayer4, RoofThicknessLayer4));
            return list;
        }
        private List<Material> Floormaterial()
        {
            List<Material> list = new List<Material>();
            list.Add(_matRep.CreateMaterial(FloorMaterialLayer1, FloorThicknessLayer1));
            list.Add(_matRep.CreateMaterial(FloorMaterialLayer2, FloorThicknessLayer2));
            list.Add(_matRep.CreateMaterial(FloorMaterialLayer3, FloorThicknessLayer3));
            list.Add(_matRep.CreateMaterial(FloorMaterialLayer4, FloorThicknessLayer4));
            return list;
        }

        private List<Material> Wallmaterial()
        {
            List<Material> list = new List<Material>();
            list.Add(_matRep.CreateMaterial(WallMaterialLayer1, WallsThicknessLayer1));
            list.Add(_matRep.CreateMaterial(WallMaterialLayer2, WallsThicknessLayer2));
            list.Add(_matRep.CreateMaterial(WallMaterialLayer3, WallsThicknessLayer3));
            list.Add(_matRep.CreateMaterial(WallMaterialLayer4, WallsThicknessLayer4));
            return list;
        }

        public float TotalHeatLoss()
        {   
            float total = CalculateHeatLossFloor() + CalculateHeatLossRoof() + (2 * CalculateHeatLossWallA()) + (2 * CalculateHeatLossWallB());
            if (IsWindy)
            {
                total *= 1.03f;
            }
            else if (IsProtectedAverage)
            {
                total *= 1.03f;
            }
            else if (IsProtectedBad)
            {
                total *= 1.06f;
            }

            return total;
        }

        public float CalculateHeatLossRoof()
        {
            var floor = new AreaRoofFloor();
            floor.ParamA = SizeA;
            floor.ParamB = SizeB;
            floor.Layers = Roofmaterial();
            return floor.CalculateQ();
        }

        public float CalculateHeatLossFloor()
        {
            var floor = new AreaRoofFloor();
            floor.ParamA = SizeA;
            floor.ParamB = SizeB;
            floor.Layers = Floormaterial();
            return floor.CalculateQ();
        }

        public float CalculateHeatLossWallA()
        {
            var floor = new AreaRoofFloor();
            floor.ParamA = SizeA;
            floor.ParamB = HeightOfWall;
            floor.Layers = Wallmaterial();
            return floor.CalculateQ();
        }
        public float CalculateHeatLossWallB()
        {
            var floor = new AreaRoofFloor();
            floor.ParamA = HeightOfWall;
            floor.ParamB = SizeB;
            floor.Layers = Wallmaterial();
            return floor.CalculateQ();
        }

    }   
}
