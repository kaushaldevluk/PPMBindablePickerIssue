using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClientCode { get; set; }
        public string ClientShortName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LocationCity { get; set; }
        public int StateID { get; set; }
        public string LocationZip { get; set; }
        public int BudgetStartMonth { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
