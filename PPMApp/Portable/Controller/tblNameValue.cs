using Portable.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Controller
{
    public class tblNameValue
    {
        IList<NameValue> lrate { get; set; }
        public IList<NameValue> GetPartSupply()
        {
            lrate = new List<NameValue>() {
                new NameValue { Value=1, Name="Parts" },
                new NameValue { Value=2, Name="Supplies" }
            };

            return lrate;
        }
    }
}
