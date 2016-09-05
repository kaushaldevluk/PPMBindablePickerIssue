using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class WorkOrderFollowUpScreen : ContentPage
    {
        public WorkOrderFollowUpScreen(int woid)
        {
            InitializeComponent();
            this.BindingContext = new WorkOrderFollowUpViewModal(woid);
        }
    }
}
