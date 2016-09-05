using Portable.Controller;
using Portable.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Portable.ViewModal
{
    public class ProjectScreenBeforeViewModal
    {

        private ICommand _photoCommand;
        private ICommand _detailCommand;
        private ICommand _deficiencyrepaircommand;
        //private ICommand _saveCommand;
        private int _LocationID;
        private bool _isback;
        private string _detail { get; set; }
        private int _height { get; set; }
        private int _width { get; set; }
        public IEnumerable<SystemElement> SystemElementList { get; set; }
        public int SESelectedValue { get; set; }
        public IEnumerable<Material> MaterialList { get; set; }
        public int MATSelectedValue { get; set; }
      

        public ProjectScreenBeforeViewModal(int ID, bool isback = false)
        {
            _isback = isback;
            tblSystemElement _tblSystemElement = new tblSystemElement();
            SystemElementList = _tblSystemElement.GetAll();
            SESelectedValue = 1;
            tblMaterial _tblMaterial = new tblMaterial();
            MaterialList = _tblMaterial.GetAll();

            if (isback == false)
            {
                _LocationID = ID;
            }
            else
            {
                Building build = new Building();
                tblBuilding dbbuild = new tblBuilding();
                build = dbbuild.Get(ID);
                _LocationID = build.LocationID;

                //build.BuildingSystemID = BSSelectedValue;
                SESelectedValue = 1;
                //build.SystemTypeID = STSelectedValue;
                //build.Rating = RTSelectedValue;
                _detail = build.Details;
                //build.IsDeficiencyRepair = true;
                //build.ProjectID = 0;
                //build.ServiceContractID = 0;
                //build.WorkOrder = "";
                //build.Compliance = "";
                _height = build.Height;
                _width = build.Width;
                MATSelectedValue = build.MaterialID;
                //build.UserID = Constant.UserID;
                //build.createon = DateTime.Now;
                //build.AddressLine1 = "";
                //build.AddressLine2 = "";
                //build.LocationCity = "";
                //build.StateID = 0;
                //build.LocationZip = "";
                //build.createon = DateTime.Now;
                //build.isedit = false;
                //build.issupload = false;
            }

        }

        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public ICommand PhotoCommand
        {
            get
            {
                return _photoCommand ?? (_photoCommand = new Command(
                                                                           async () => await UploadPhoto(),
                                                                           () => true));
            }
        }

        public ICommand DetailCommand
        {
            get
            {
                return _detailCommand ?? (_detailCommand = new Command(
                                                                           async () => await DetailPage(),
                                                                           () => true));
            }
        }


        public ICommand DeficiencyRepairCommand
        {
            get
            {
                return _deficiencyrepaircommand ?? (_deficiencyrepaircommand = new Command(
                                                                           async () => await DeficiencyRepair(),
                                                                           () => true));
            }
        }

        public async Task UploadPhoto()
        {
            int buildingID = SaveDetail();
            App.Current.MainPage = new MainPageCS(new CameraPage(buildingID, "ProjectScreenBefore"));
        }

        public async Task DeficiencyRepair()
        {
            int buildingID = SaveDetail();
            App.Current.MainPage = new MainPageCS(new DeficiencyRepairScreen(buildingID));
        }
        public async Task DetailPage()
        {

        }

        public int SaveDetail()
        {
            Building build = new Building();
            tblBuilding dbbuild = new tblBuilding();
            build.LocationID = _LocationID;
            build.BuildingCode = "";
            //build.BuildingSystemID = BSSelectedValue;
            build.SystemElementID = SESelectedValue;
            //build.SystemTypeID = STSelectedValue;
            //build.Rating = RTSelectedValue;
            build.Details = _detail;
            //build.IsDeficiencyRepair = true;
            build.ProjectID = 0;
            build.ServiceContractID = 0;
            build.WorkOrder = "";
            build.Compliance = "";
            build.Height = _height;
            build.Width = _width;
            build.MaterialID = MATSelectedValue;
            build.UserID = Constant.UserID;
            build.createon = DateTime.Now;
            build.AddressLine1 = "";
            build.AddressLine2 = "";
            build.LocationCity = "";
            build.StateID = 0;
            build.LocationZip = "";
            build.createon = DateTime.Now;
            build.isedit = false;
            build.issupload = false;
            //build.IsDeficiencyRepair = await App.Current.MainPage.DisplayAlert("FCA Deficiency Screen", "is this Deficiency/Repair ?", "Yes", "No");
            int bid = dbbuild.Add(build);
            return bid;
            //App.Current.MainPage = new MainPageCS(new CameraPage(bid, "ProjectScreenBefore"));

        }
    }
}
