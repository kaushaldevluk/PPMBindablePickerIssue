using Portable.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Controller
{
    public class tblPriority
    {
        IList<Priority> lrate { get; set; }
        public IList<Priority> GetAll()
        {
            lrate = new List<Priority>() {
                new Priority { Value=1, Name="A" },
                new Priority { Value=2, Name="B" },
                new Priority { Value=3, Name="C" },
                new Priority { Value=4, Name="D" },
                new Priority { Value=5, Name="E" }
            };

            return lrate;
        }
    }
}
