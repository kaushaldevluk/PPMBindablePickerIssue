using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class WorkOrderFollowUp
    {
        [PrimaryKey, AutoIncrement]
        public int WorkOrderFollowUpID { get; set; }
        public int WorkOrderID { get; set; }
        public DateTime DateCompleted { get; set; }
        public int Labour { get; set; }
        public string PartsSuppies { get; set; }
        public string Note { get; set; }
        public string NoteAudio { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
