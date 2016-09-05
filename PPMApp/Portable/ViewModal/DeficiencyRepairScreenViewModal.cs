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
    public class DeficiencyRepairScreenViewModal
    {
        private int _BuildingID;
        private string _detail { get; set; }
        private int _qty { get; set; }
        private int _unit { get; set; }
        private int _workArea { get; set; }
        private string _note { get; set; }
        private ICommand _saveCommand;

        public DeficiencyRepairScreenViewModal(int bid)
        {
            _BuildingID = bid;
        }
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        public int Quantity
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public int Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public int WorkArea
        {
            get { return _workArea; }
            set { _workArea = value; }
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
            tblBuildingDeficiencyRepair _tblBuildingDeficiencyRepair = new tblBuildingDeficiencyRepair();
            BuildingDeficiencyRepair bdr = new BuildingDeficiencyRepair();
            //public int BuildingDeficiencyRepairID { get; set; }
            bdr.BuildingID = _BuildingID;
            bdr.Description = _detail;
            bdr.Quantity = _qty;
            bdr.Units = _unit;
            bdr.Priority = "";
            bdr.Note = _note;
            bdr.NoteAudio = "";
            bdr.WorkAreaNo = _workArea;
            bdr.UserID = Constant.UserID;
            bdr.createon = DateTime.Now;
            bdr.issupload = false;
            bdr.isedit = false;
            int bdrid = _tblBuildingDeficiencyRepair.Add(bdr);
            App.Current.MainPage = new MainPageCS(new CameraPage(bdrid, "BuildingDeficiencyRepairScreen"));
        }
    }
}
