using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int ProjectID { get; set; }
        public int BuildingSystemID { get; set; }
        public string ProjectName { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
