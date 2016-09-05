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
    public class FacilityViewModal
    {
        private int _locid;
        private tblBuildingSystem _tblBuildingSystem;
        private tblProject _tblProject;
        private tblServiceContract _tblServiceContract;
        
        public IList<BuildingSystem> BuildingSystemList { get; set; }
        public int BSSelectedValue { get; set; }
        public IList<Project> ProjectList { get; set; }
        public int PLSelectedValue { get; set; }
        public IList<ServiceContract> ServiceContractList { get; set; }
        public int SCSelectedValue { get; set; }
        public IList<Compliance> ComplianceList { get; set; }
        public int CMSelectedValue { get; set; }
        private string _detail { get; set; }
        private ICommand _saveCommand;

        public FacilityViewModal(int locid)
        {
            _locid = locid;

            _tblBuildingSystem = new tblBuildingSystem();
            _tblProject = new tblProject();
            _tblServiceContract = new tblServiceContract();
            
            BuildingSystemList = _tblBuildingSystem.GetAll();
            ProjectList = _tblProject.GetAll();
            ServiceContractList = _tblServiceContract.GetAll();
        }

        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
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

        public async Task SaveDetail()
        {
            Building build = new Building();
            tblBuilding dbbuild = new tblBuilding();
            tblCompliance com = new tblCompliance();
            build.LocationID = _locid;
            build.BuildingCode = "";
            build.BuildingSystemID = BSSelectedValue;
            build.SystemElementID = 0;
            build.SystemTypeID = 0;
            build.Rating = 0;
            build.Details = _detail;
            //build.IsDeficiencyRepair = true;
            build.ProjectID = PLSelectedValue;
            build.ServiceContractID = SCSelectedValue;
            build.WorkOrder = "";
            build.Compliance = com.Get(CMSelectedValue);
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
            build.IsDeficiencyRepair = false;
            bool ans = await App.Current.MainPage.DisplayAlert("Work Order", "Request for Work Order", "Yes", "No");
            if (ans == true)
            {
                build.WorkOrder = "1";
            }
            else
            {
                build.WorkOrder = "";
            }
            
            int bid = dbbuild.Add(build);
            App.Current.MainPage = new MainPageCS(new CameraPage(bid, "Facility"));
        }
    }
}
