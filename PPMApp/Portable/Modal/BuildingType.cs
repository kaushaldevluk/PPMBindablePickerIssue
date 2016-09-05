using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class BuildingType
    {
        [PrimaryKey, AutoIncrement]
        public int BuildingTypeID { get; set; }
        public string BuildingTypeName { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
