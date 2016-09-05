using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class ProposalCheckListFlatRoof
    {
        [PrimaryKey, AutoIncrement]
        public int ProposalCheckListID { get; set; }
        public int BuildingID { get; set; }
        public string Insualtion { get; set; }
        public string Deck { get; set; }
        public int NoofDrains { get; set; }
        public string Protrusions { get; set; }
        public string BaseFlashing { get; set; }
        public string CounterFlashing { get; set; }
        public string Asbestos { get; set; }
        public string SubRoofs { get; set; }
        public string InteriorParapet { get; set; }
        public string Coping { get; set; }
        public string Railings { get; set; }
        public string Access { get; set; }
        public string Chimneys { get; set; }
        public string Dumpsters { get; set; }
        public int UserID { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
