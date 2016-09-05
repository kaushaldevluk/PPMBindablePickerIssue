using Portable.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Controller
{
    public class tblCompliance
    {
        IList<Compliance> lrate { get; set; }
        public static string First = "Proposal (Before)";
        public static string Second = "Active (Progress)";
        public static string Third = "Post-Construction (After)";
        public static string Fourth = "Other:";
        public IList<Compliance> GetAll()
        {
            lrate = new List<Compliance>() {
                new Compliance { Value=1, Name=First },
                new Compliance { Value=2, Name=Second },
                new Compliance { Value=3, Name=Third },
                new Compliance { Value=4, Name=Fourth }
                
            };

            return lrate;
        }

        public string Get(int Value)
        {
            if (Value == 1)
            {
                return First;
            }
            else if (Value == 2)
            {
                return Second;
            }
            else if (Value == 3)
            {
                return Third;
            }
            else if (Value == 4)
            {
                return Fourth;
            }
            else
            {
                return "";
            }
            
        }
    }
}
