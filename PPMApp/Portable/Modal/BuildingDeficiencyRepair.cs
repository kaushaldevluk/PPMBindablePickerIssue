using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class BuildingDeficiencyRepair
    {
        [PrimaryKey, AutoIncrement]
        public int BuildingDeficiencyRepairID { get; set; }
        public int BuildingID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public string Priority { get; set; }
        public string Note { get; set; }
        public string NoteAudio { get; set; }
        public int WorkAreaNo { get; set; }
        public int UserID { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
