using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W3D2_TemperatureLost
{
    public partial class MainView : Form
    {
        private ViewModel _vm;
        // constuctor        
        public MainView(ViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            #region init of comboxes
            cmbWallMaterial1.DataSource = _vm.GetMeterialsKeys().ToList();
            cmbWallMaterial2.DataSource = _vm.GetMeterialsKeys().ToList();
            cmbWallMaterial3.DataSource = _vm.GetMeterialsKeys().ToList();
            cmbWallMaterial4.DataSource = _vm.GetMeterialsKeys().ToList();
            cmbFloorMaterial1.DataSource = vm.GetMeterialsKeys().ToList();
            cmbFloorMaterial2.DataSource = vm.GetMeterialsKeys().ToList();
            cmbFloorMaterial3.DataSource = vm.GetMeterialsKeys().ToList();
            cmbFloorMaterial4.DataSource = vm.GetMeterialsKeys().ToList();
            cmbRoofMaterial1.DataSource = vm.GetMeterialsKeys().ToList();
            cmbRoofMaterial2.DataSource = vm.GetMeterialsKeys().ToList();
            cmbRoofMaterial3.DataSource = vm.GetMeterialsKeys().ToList();
            cmbRoofMaterial4.DataSource = vm.GetMeterialsKeys().ToList();
            #endregion
        }



        private void MainView_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Collects data from fomular
        /// 
        /// </summary>
        private void GetData()
        {
            _vm.BuildingName = txtBxBuildingName.Text;
            _vm.FirstNameAuth = txtBxAuthFirstname.Text;
            _vm.LastNanemAuth = txtBxAuthLastname.Text;
            // Is windy?
            if (rdBtnCountryWindy.Checked == true)
            {
                _vm.IsWindy = true;
            }
            // Is protected?
            if (rdBtnProtectionAverage.Checked == true)
            {
                _vm.IsProtectedAverage = true;
                _vm.IsProtectedBad = false;
            }
            else if (rdBtnProtectionBad.Checked == true)
            {
                _vm.IsProtectedAverage = false;
                _vm.IsProtectedBad = true;
            }
            else
            {
                _vm.IsProtectedAverage = false;
                _vm.IsProtectedBad = false;
            }

            _vm.SizeA = float.Parse(nmrSizeA.Text);
            _vm.SizeB = float.Parse(nmrSizeB.Text);
            _vm.HeightOfWall = float.Parse(nmrHeight.Text);

            #region settig layers of wall
            _vm.WallMaterialLayer1 = cmbWallMaterial1.Text;
            _vm.WallMaterialLayer2 = cmbWallMaterial2.Text;
            _vm.WallMaterialLayer3 = cmbWallMaterial3.Text;
            _vm.WallMaterialLayer4 = cmbWallMaterial4.Text;

            _vm.WallsThicknessLayer1 = float.Parse(nmrWallThicknes1.Text);
            _vm.WallsThicknessLayer2 = float.Parse(nmrWallThicknes2.Text);
            _vm.WallsThicknessLayer3 = float.Parse(nmrWallThicknes3.Text);
            _vm.WallsThicknessLayer4 = float.Parse(nmrWallThicknes4.Text);
            #endregion

            #region setting layers of roof
            _vm.RoofMaterialLayer1 = cmbRoofMaterial1.Text;
            _vm.RoofMaterialLayer2 = cmbRoofMaterial2.Text;
            _vm.RoofMaterialLayer3 = cmbRoofMaterial3.Text;
            _vm.RoofMaterialLayer4 = cmbRoofMaterial4.Text;

            _vm.RoofThicknessLayer1 = float.Parse(nmrRoofThickness1.Text);
            _vm.RoofThicknessLayer2 = float.Parse(nmrRoofThickness2.Text);
            _vm.RoofThicknessLayer3 = float.Parse(nmrRoofThickness3.Text);
            _vm.RoofThicknessLayer4 = float.Parse(nmrRoofThickness4.Text);
            #endregion

            #region setting layers of floor
            _vm.FloorMaterialLayer1 = cmbFloorMaterial1.Text;
            _vm.FloorMaterialLayer2 = cmbFloorMaterial2.Text;
            _vm.FloorMaterialLayer3 = cmbFloorMaterial3.Text;
            _vm.FloorMaterialLayer4 = cmbFloorMaterial4.Text;

            _vm.FloorThicknessLayer1 = float.Parse(nmrFloorThickness1.Text);
            _vm.FloorThicknessLayer2 = float.Parse(nmrFloorThickness2.Text);
            _vm.FloorThicknessLayer3 = float.Parse(nmrFloorThickness3.Text);
            _vm.FloorThicknessLayer4 = float.Parse(nmrFloorThickness4.Text);
            #endregion

        }

        private void BtnConfirmAll_Click(object sender, EventArgs e)
        {
            GetData();
            txtBxTotal.Text= _vm.TotalHeatLoss().ToString();
            groupBox5.Visible = true;
        }
    }
}
