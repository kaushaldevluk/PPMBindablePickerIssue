using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class ServiceContract
    {
        [PrimaryKey, AutoIncrement]
        public int ServiceContractID { get; set; }
        public int ProjectID { get; set; }        
        public string ServiceContractName { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
