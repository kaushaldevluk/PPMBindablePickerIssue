using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class Building
    {
        [PrimaryKey, AutoIncrement]
        public int BuildingID { get; set; }
        public string BuildingCode { get; set; }
        public int LocationID { get; set; }
        
        public int BuildingSystemID { get; set; }
        
        public int SystemElementID { get; set; }
        
        public int SystemTypeID { get; set; }
        
        public int Rating { get; set; }
        public string Details { get; set; }
        public bool IsDeficiencyRepair { get; set; }
        public int ProjectID { get; set; }
        public int ServiceContractID { get; set; }
        public string WorkOrder { get; set; }
        public string Compliance { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int MaterialID { get; set; }
         public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LocationCity { get; set; }
        public int StateID { get; set; }
        public int UserID { get; set; }
        public string LocationZip { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
