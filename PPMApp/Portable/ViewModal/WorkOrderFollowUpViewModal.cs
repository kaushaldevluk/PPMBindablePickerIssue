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
    public class WorkOrderFollowUpViewModal
    {
        private ICommand _saveCommand;
        private tblLabour _tblLabour;
        private tblNameValue _tblNameValue;
        private int _WorkOrderID;
        private DateTime _PropertyDate { get; set; }
        private string _assign { get; set; }
        public IList<Labour> LabourList { get; set; }
        public int LBSelectedValue { get; set; }
        public IList<NameValue> PartSupplyList { get; set; }
        public string PSSelectedValue { get; set; }
        public string _note { get; set; }
        public WorkOrderFollowUpViewModal(int woid)
        {
            _WorkOrderID = woid;
            _PropertyDate = DateTime.Now;
            _tblLabour = new tblLabour();
            _tblNameValue = new tblNameValue();
            LabourList = _tblLabour.GetAll();
            PartSupplyList = _tblNameValue.GetPartSupply();
        }
       
        public DateTime PropertyMaximumDate
        {
            get { return DateTime.Now; }
        }
        public DateTime PropertyMinimumDate
        {
            get { return Convert.ToDateTime("01-Jan-2000"); }
        }
        public DateTime PropertyDate
        {
            get { return _PropertyDate; }
            set { _PropertyDate = value; }
        }
        public string Assign
        {
            get { return _assign; }
            set { _assign = value; }
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
            WorkOrderFollowUp wof = new WorkOrderFollowUp();
            wof.WorkOrderID = _WorkOrderID;
            wof.DateCompleted = _PropertyDate;
            wof.Labour = LBSelectedValue;
            wof.PartsSuppies = PSSelectedValue;
            wof.Note = _note;
            wof.NoteAudio = "";
            wof.createon = DateTime.Now;
            wof.issupload = false;
            wof.isedit = false;

            tblWorkOrderFollowUp DBwof = new tblWorkOrderFollowUp();
            int wofid = DBwof.Add(wof);
            App.Current.MainPage = new MainPageCS(new CameraPage(wofid, "WorkOrderFollowUp"));
        }
    }
}
