using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Portable.Controller;
using Portable.Modal;
namespace Portable.ViewModal
{
    public class ProposalChecklistFlatRoofViewModal
    {
        private int _BuildingID;
        private int _userid;
        private ICommand _saveCommand;

        private string _insualtion { get; set; }
        private string _deck { get; set; }
        private int _noofdrains { get; set; }
        private string _protrusions { get; set; }
        private string _baseflashing { get; set; }
        private string _counterflashing { get; set; }
        private string _asbestos { get; set; }
        private string _subroofs { get; set; }
        private string _interiorparapet { get; set; }
        private string _coping { get; set; }
        private string _railings { get; set; }
        private string _access { get; set; }
        private string _chimneys { get; set; }
        private string _dumpsters { get; set; }
        public ProposalChecklistFlatRoofViewModal(int BuildingID)
        {
            _BuildingID = BuildingID;
            _userid = Constant.UserID;
        }
        public string Insualtion
        {
            get { return _insualtion; }
            set { _insualtion = value;  }
        }
        public string Deck
        {
            get { return _deck; }
            set { _deck = value; }
        }

        public int NoOfDrains
        {
            get { return _noofdrains; }
            set { _noofdrains = value; }
        }

        public string Protrusions
        {
            get { return _protrusions; }
            set { _protrusions = value; }
        }

        public string BaseFlashing
        {
            get { return _baseflashing; }
            set { _baseflashing = value; }
        }

        public string CounterFlashing
        {
            get { return _counterflashing; }
            set { _counterflashing = value; }
        }

        public string Asbestos
        {
            get { return _asbestos; }
            set { _asbestos = value; }
        }

        public string Subroofs
        {
            get { return _subroofs; }
            set { _subroofs = value; }
        }

        public string Interiorparapet
        {
            get { return _interiorparapet; }
            set { _interiorparapet = value; }
        }

        public string Coping
        {
            get { return _coping; }
            set { _coping = value; }
        }

        public string Railings
        {
            get { return _railings; }
            set { _railings = value; }
        }

        public string Access
        {
            get { return _access; }
            set { _access = value; }
        }
        public string Chimneys
        {
            get { return _chimneys; }
            set { _chimneys = value; }
        }
        public string DumpSters
        {
            get { return _dumpsters; }
            set { _dumpsters = value; }
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
            tblProposalCheckListFlatRoof DB = new tblProposalCheckListFlatRoof();
            ProposalCheckListFlatRoof tab = new ProposalCheckListFlatRoof();
            tab.BuildingID = _BuildingID;
            tab.Insualtion = _insualtion;
            tab.Deck = _deck;
            tab.NoofDrains = _noofdrains;
            tab.Protrusions = _protrusions;
            tab.BaseFlashing = _baseflashing;
            tab.CounterFlashing = _counterflashing;
            tab.Asbestos = _asbestos;
            tab.SubRoofs = _subroofs;
            tab.InteriorParapet = _interiorparapet;
            tab.Coping = _coping;
            tab.Railings = _railings;
            tab.Access = _access;
            tab.Chimneys = _chimneys;
            tab.Dumpsters = _dumpsters;
            tab.UserID = Constant.UserID;
            tab.createon = DateTime.Now;
            tab.issupload = false;
            tab.isedit = false;
            DB.Add(tab);
            App.Current.MainPage = new MainPageCS(new DeficiencyRepairScreen(_BuildingID));

        }
    }
}
