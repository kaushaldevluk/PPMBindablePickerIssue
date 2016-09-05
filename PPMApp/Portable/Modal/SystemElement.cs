using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class SystemElement
    {
        [PrimaryKey, AutoIncrement]
        public int SystemElementID { get; set; }
        public int BuildingSystemID { get; set; }
        public string SystemElementName { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
