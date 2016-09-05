using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class LocationListModal
    {
        public int LocationId { get; set; }
        public int ClientID { get; set; }
        public string BuildingName { get; set; }
        public string ClientName { get; set; }
        public bool sync { get; set; }
    }
}