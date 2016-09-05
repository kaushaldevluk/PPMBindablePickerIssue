using Portable.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Controller
{
    public class tblRating
    {
        IList<Rating> lrate { get; set; }
        public IList<Rating> GetAll()
        {
            lrate = new List<Rating>() {
                new Rating { Value=1, Name="Poor" },
                new Rating { Value=2, Name="Good" },
                new Rating { Value=2, Name="Very Good" }
            };

            return lrate;
        }
    }
}
