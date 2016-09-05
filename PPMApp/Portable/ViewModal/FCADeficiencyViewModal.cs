using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portable.Modal;
using Portable.Controller;
using System.Windows.Input;
using Xamarin.Forms;

namespace Portable.ViewModal
{
    public class FCADeficiencyViewModal
    {
        private tblBuildingDeficiencyRepair _tblBuildingDeficiencyRepair;
        private tblPriority _tblPriority;

        private int _BuildingID;
        private string _detail { get; set; }
        private int _qty { get; set; }
        private int _unit { get; set; }
        public IList<Priority> PriorityList { get; set; }
        public string PLSelectedvalue { get; set; }
        private string _note { get; set; }
        private ICommand _saveCommand;


        public FCADeficiencyViewModal(int id)
        {
            _tblBuildingDeficiencyRepair = new tblBuildingDeficiencyRepair();
            _tblPriority = new tblPriority();
            _BuildingID = id;
            PriorityList = _tblPriority.GetAll();
        }
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        public int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public int Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; }
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
            BuildingDeficiencyRepair bdr = new BuildingDeficiencyRepair();
            //public int BuildingDeficiencyRepairID { get; set; }
            bdr.BuildingID = _BuildingID;
            bdr.Description = _detail;
            bdr.Quantity = _qty;
            bdr.Units = _unit;
            bdr.Priority = PLSelectedvalue.ToString();
            bdr.Note = _note;
            bdr.NoteAudio = "";
            bdr.WorkAreaNo = 0;
            bdr.UserID = Constant.UserID;
            bdr.createon = DateTime.Now;
            bdr.issupload = false;
            bdr.isedit = false;
            int bdrid =_tblBuildingDeficiencyRepair.Add(bdr);
            App.Current.MainPage = new MainPageCS(new CameraPage(bdrid, "BuildingDeficiencyRepair"));
        }
    }
}
