using System;
using System.Collections;
using System.Collections.Generic;
using Telerik.XamarinForms.Input.DataForm;
namespace Portable
{
    public class BuildingEntryDSP : PropertyDataSourceProvider
    {
        public override IList GetSourceForKey(object key)
        {
            if (key.Equals("ClientName"))
            {
                return new List<string>
                {
                    "Client 1",
                    "Client 2",
                    "Client 3",
                    "Client 4"

                };
            }

            if (key.Equals("Institution"))
            {
                return new List<string>
                {
                    "Institution 1",
                    "Institution 2",
                    "Institution 3",
                    "Institution 4"

                };
            }

            if (key.Equals("Building"))
            {
                return new List<string>
                {
                    "Church",
                    "School",
                    "Residence",
                    "Gym/Auditorium",
                    "Other"
                };
            }

            if (key.Equals("Job"))
            {
                return new List<string>
                {
                    "Exterior Restoration",
                    "Interior/GC",
                    "FCA/ Planning",
                    "Facility Maintenance",
                    "Other"
                };
            }

            if (key.Equals("Status"))
            {
                return new List<string>
                {
                    "Proposal (Before)",
                    "Active (Progress)",
                    "Post-Construction (After)",                   
                    "Other"
                };
            }

            return null;
        }
    }
}
