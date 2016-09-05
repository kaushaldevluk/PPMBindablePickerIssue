using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.Common.DataAnnotations;

namespace Portable
{
    public class tblClient : NotifyPropertyChangedBase
    {
        private int id;
        private string name;
        private DateTime createdOn = DateTime.Now;
        private bool isupload = false;
        private bool isEdit = false;

        [DisplayOptions(Header = "Name", PlaceholderText = "Name")]
        [StringLengthValidator(2, int.MaxValue, "Name is too Short")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
