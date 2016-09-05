using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class users
    {
        [PrimaryKey, AutoIncrement]
        public int userid { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string devicetype { get; set; }
        public string deviceid { get; set; }
        public bool isactive { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
