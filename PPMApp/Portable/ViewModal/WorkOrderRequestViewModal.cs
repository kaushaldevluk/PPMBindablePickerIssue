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
    public class WorkOrderRequestViewModal
    {
        private int _BuildingID;
        private ICommand _saveCommand;
        private tblPriority _tblPriority;
        private string _detail { get; set; }
        private tblBuildingSystem _tblBuildingSystem;
        public IList<BuildingSystem> BuildingSystemList { get; set; }
        public int BSSelectedValue { get; set; }

        public IList<Component> ComponentList { get; set; }
        public int CPSelectedValue { get; set; }
        public IList<Priority> PriorityList { get; set; }
        public string PLSelectedvalue { get; set; }
        private string _requestor { get; set; }
        public WorkOrderRequestViewModal(int bid)
        {
            
            _BuildingID = bid;
            _tblBuildingSystem = new tblBuildingSystem();
            BuildingSystemList = _tblBuildingSystem.GetAll();
            _tblPriority = new tblPriority();           
            PriorityList = _tblPriority.GetAll();
        }

        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        public string Requestor
        {
            get { return _requestor; }
            set { _requestor = value; }
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
            tblBuildingWorkOrder _tblBuildingWorkOrder = new tblBuildingWorkOrder();
            BuildingWorkOrder _BuildingWorkOrder = new BuildingWorkOrder();

            _BuildingWorkOrder.BuildingID = _BuildingID;
            _BuildingWorkOrder.BuildingSystemID = BSSelectedValue;
            _BuildingWorkOrder.ComponentID = CPSelectedValue;
            _BuildingWorkOrder.Description = _detail;
            _BuildingWorkOrder.Priority = PLSelectedvalue;
            _BuildingWorkOrder.Requestor = "";
            _BuildingWorkOrder.createon = DateTime.Now;
            _BuildingWorkOrder.issupload = false;
            _BuildingWorkOrder.isedit = false;
            int woid = _tblBuildingWorkOrder.Add(_BuildingWorkOrder);

            App.Current.MainPage = new MainPageCS(new CameraPage(woid, "WorkOrder"));
        }
    }
}
