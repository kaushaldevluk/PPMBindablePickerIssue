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
    public class ProposalChecklistExteriorWallsViewModal
    {
        private ICommand _saveCommand;
        private int _BuildingID;
        private string _SidewalkBridge { get; set; }
        private string _Scaffold { get; set; }
        private string _Hoist { get; set; }
        private int _NoofDrops { get; set; }
        private int _NoofLintels { get; set; }
        private string _QtyCaulking { get; set; }
        private string _DutchmanRepairs { get; set; }
        private int _NoSillsReplacesCapped { get; set; }
        private string _MetalPanelsReplaced { get; set; }
        private string _StoneReplacement { get; set; }
        private string _BrickReplacement { get; set; }
        private string _Chutes { get; set; }
        private int _NoofWythes { get; set; }
        private string _Dumpsters { get; set; }
        public ProposalChecklistExteriorWallsViewModal(int BuildingID)
        {
            _BuildingID = BuildingID;
        }
        public string SidewalkBridge
        {
            get { return _SidewalkBridge; }
            set { _SidewalkBridge = value; }
        }
        public string Scaffold
        {
            get { return _Scaffold; }
            set { _Scaffold = value; }
        }
        public string Hoist
        {
            get { return _Hoist; }
            set { _Hoist = value; }
        }
        public int NoofDrops
        {
            get { return _NoofDrops; }
            set { _NoofDrops = value; }
        }
        public int NoofLintels
        {
            get { return _NoofLintels; }
            set { _NoofLintels = value; }
        }
        public string QtyCaulking
        {
            get { return _QtyCaulking; }
            set { _QtyCaulking = value; }
        }
        public string DutchmanRepairs
        {
            get { return _DutchmanRepairs; }
            set { _DutchmanRepairs = value; }
        }
        public int NoSillsReplacesCapped
        {
            get { return _NoSillsReplacesCapped; }
            set { _NoSillsReplacesCapped = value; }
        }
        public string MetalPanelsReplaced
        {
            get { return _MetalPanelsReplaced; }
            set { _MetalPanelsReplaced = value; }
        }
        public string StoneReplacement
        {
            get { return _StoneReplacement; }
            set { _StoneReplacement = value; }
        }
        public string BrickReplacement
        {
            get { return _BrickReplacement; }
            set { _BrickReplacement = value; }
        }
        public string Chutes
        {
            get { return _Chutes; }
            set { _Chutes = value; }
        }
        public int NoofWythes
        {
            get { return _NoofWythes; }
            set { _NoofWythes = value; }
        }
        public string Dumpsters
        {
            get { return _Dumpsters; }
            set { _Dumpsters = value; }
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
            tblProposalChecklistExteriorWalls DB = new tblProposalChecklistExteriorWalls();
            ProposalChecklistExteriorWalls tab = new ProposalChecklistExteriorWalls();
            tab.BuildingID = _BuildingID;
            tab.SidewalkBridge = _SidewalkBridge;
            tab.Scaffold= _Scaffold;
            tab.Hoist = _Hoist;
            tab.NoofDrops = _NoofDrops;
            tab.NoofLintels = _NoofLintels;
            tab.QtyCaulking= _QtyCaulking;
            tab.DutchmanRepairs = _DutchmanRepairs;
            tab.NoSillsReplacesCapped= _NoSillsReplacesCapped;
            tab.MetalPanelsReplaced= _MetalPanelsReplaced;
            tab.StoneReplacement = _StoneReplacement;
            tab.BrickReplacement = _BrickReplacement;
            tab.Chutes= _Chutes;
            tab.NoofWythes= _NoofWythes;
            tab.Dumpsters = _Dumpsters;
            tab.UserID = Constant.UserID;
            tab.createon = DateTime.Now;
            tab.issupload = false;
            tab.isedit = false;
            DB.Add(tab);
            App.Current.MainPage = new MainPageCS(new DeficiencyRepairScreen(_BuildingID));
        }
    }
}
