using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class InstitutionType
    {
        [PrimaryKey, AutoIncrement]
        public int InstitutionTypeID { get; set; }
        public string InstitutionTypeName { get; set; }
    }
}
