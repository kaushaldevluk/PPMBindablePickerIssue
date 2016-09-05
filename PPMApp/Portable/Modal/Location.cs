using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Portable.Modal
{
    public class Location
    {

        [PrimaryKey, AutoIncrement]
        public int LocationId { get; set; }
        public int ClientID { get; set; }
        public int InstitutionID { get; set; }
        public string Building { get; set; }
        public int JobTypeID { get; set; }
        public int BuildingTypeID { get; set; }
        public int JobStatusID { get; set; }

        public string JobDetail { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }



    }
}
