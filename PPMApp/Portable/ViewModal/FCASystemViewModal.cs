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
    public class FCASystemViewModal
    {
        private tblBuildingSystem _tblBuildingSystem;
        private tblSystemElement _tblSystemElement;
        private tblRating _tblRating;
        private tblSystemType _tblSystemType;
        public string _detail { get; set; }
        private int _locid;
        public IList<BuildingSystem> BuildingSystemList { get; set; }
        public int BSSelectedValue { get; set; }

        public IList<SystemElement> SystemElementList { get; set; }
        public int SESelectedValue { get; set; }
        //public string BSSelectedItem { get; set; }
        public IList<Rating> RatingList { get; set; }
        public int RTSelectedValue { get; set; }
        public IList<string> isRepairList { get; set; }
        public int RepairSelectedValue { get; set; }
        public IList<SystemType> SystemTypeList { get; set; }
        public int STSelectedValue { get; set; }


        private ICommand _saveCommand;
        public FCASystemViewModal(int id)
        {
            _locid = id;
            _tblBuildingSystem = new tblBuildingSystem();
            _tblSystemElement = new tblSystemElement();
            _tblRating = new tblRating();
            _tblSystemType = new tblSystemType();

            BuildingSystemList = _tblBuildingSystem.GetAll();
            SystemElementList = new List<SystemElement>()
            {
                new SystemElement { SystemElementID = 0, SystemElementName = "Select System Element" }
            };
            RatingList = _tblRating.GetAll();
            SystemTypeList = _tblSystemType.GetAll();
            //isRepairList = new IList<string> { "Yes", "No"};
        }
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(
                                                                           async () => await SaveDetail(),
                                                                           () => true));
            }
        }
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        public async Task SaveDetail()
        {
            tblLocation dbloc = new tblLocation();
            Location loc = new Location();
            loc = dbloc.Get(_locid);
            Building build = new Building();
            tblBuilding dbbuild = new tblBuilding();
            build.LocationID = _locid;
            build.BuildingCode = "";
            build.BuildingSystemID = BSSelectedValue;
            build.SystemElementID = SESelectedValue;
            build.SystemTypeID = STSelectedValue;
            build.Rating = RTSelectedValue;
            build.Details = _detail;
            //build.IsDeficiencyRepair = true;
            build.ProjectID = 0;
            build.ServiceContractID = 0;
            build.WorkOrder = "";
            build.Compliance = "";
            build.Height = 0;
            build.Width = 0;
            build.MaterialID = 0;
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
            build.IsDeficiencyRepair = await App.Current.MainPage.DisplayAlert("FCA Deficiency Screen", "is this Deficiency/Repair ?", "Yes", "No");
            int bid = dbbuild.Add(build);
            App.Current.MainPage = new MainPageCS(new CameraPage(bid, "FCA"));
        }
    }
}
