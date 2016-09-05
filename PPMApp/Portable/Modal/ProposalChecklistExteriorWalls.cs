using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class ProposalChecklistExteriorWalls
    {
        [PrimaryKey, AutoIncrement]
        public int ProposalCheckExteriorWallsid { get; set; }
        public int BuildingID { get; set; }
        public string SidewalkBridge { get; set; }
        public string Scaffold { get; set; }
        public string Hoist { get; set; }
        public int NoofDrops { get; set; }
        public int NoofLintels { get; set; }
        public string QtyCaulking { get; set; }
        public string DutchmanRepairs { get; set; }
        public int NoSillsReplacesCapped { get; set; }
        public string MetalPanelsReplaced { get; set; }
        public string StoneReplacement { get; set; }
        public string BrickReplacement { get; set; }
        public string Chutes { get; set; }
        public int NoofWythes { get; set; }
        public string Dumpsters { get; set; }
        public int UserID { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
