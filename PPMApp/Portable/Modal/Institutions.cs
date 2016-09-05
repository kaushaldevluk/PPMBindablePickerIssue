using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class Institutions
    {
        [PrimaryKey, AutoIncrement]
        public int InstitutionID { get; set; }
        public string InstitutionCode { get; set; }
        public int InstitutionTypeID { get; set; }
        public string ShortName { get; set; }
        public string LegalName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LocationCity { get; set; }
        public int StateID { get; set; }
        public string LocationZip { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
