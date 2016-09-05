using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class ProjectScreenBefore : ContentPage
    {
        public ProjectScreenBefore(int LocID,bool isback = false)
        {
            InitializeComponent();
            this.BindingContext = new ProjectScreenBeforeViewModal(LocID,isback);
        }
    }
}
