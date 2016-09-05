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
    public class ProposalChecklistPitchedRoofViewModal
    {
        private int _BuildingID;
        private int _userid;
        private ICommand _saveCommand;
        private string _deck { get; set; }
        private int _noofdrains { get; set; }
        private string _protrusions { get; set; }
        private string _iceandwatershield { get; set; }
        private string _vallerys { get; set; }
        private string _ridgecaps { get; set; }
        private string _asbestos { get; set; }
        private string _subroofs { get; set; }
        private string _rakingwallflashing { get; set; }
        private string _rakingwallcoping { get; set; }
        private string _railings { get; set; }
        private string _access { get; set; }
        private string _chimneys { get; set; }
        private string _dumpsters { get; set; }
        public ProposalChecklistPitchedRoofViewModal()
        {

        }
        public string IceandWaterShild
        {
            get { return _iceandwatershield; }
            set { _iceandwatershield = value; }
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
        public string Valleys
        {
            get { return _vallerys; }
            set { _vallerys = value; }
        }
        public string RidgeCaps
        {
            get { return _ridgecaps; }
            set { _ridgecaps = value; }
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

        public string RakingWallFlashing
        {
            get { return _rakingwallflashing; }
            set { _rakingwallflashing = value; }
        }
        public string RakingWallCoping
        {
            get { return _rakingwallcoping; }
            set { _rakingwallcoping = value; }
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
            tblProposalCheckListPitchedRoof DB = new tblProposalCheckListPitchedRoof();
            ProposalCheckListPitchedRoof tab = new ProposalCheckListPitchedRoof();
            tab.BuildingID = _BuildingID;
            tab.Iceandwatershield = _iceandwatershield;
            tab.Deck = _deck;
            tab.NoofDrains = _noofdrains;
            tab.Protrusions = _protrusions;
            tab.Vallerys = _vallerys;
            tab.Ridgecaps = _ridgecaps;
            tab.Asbestos = _asbestos;
            tab.SubRoofs = _subroofs;
            tab.RakingWallFlashing = _rakingwallflashing;
            tab.RakingWallCoping = _rakingwallcoping;
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
