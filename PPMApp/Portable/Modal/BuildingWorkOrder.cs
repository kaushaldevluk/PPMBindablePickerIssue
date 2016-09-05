using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class BuildingWorkOrder
    {
        [PrimaryKey, AutoIncrement]
        public int WorkOrderID { get; set; }
        public int BuildingID { get; set; }
        public int BuildingSystemID { get; set; }
        public int ComponentID { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Requestor { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
