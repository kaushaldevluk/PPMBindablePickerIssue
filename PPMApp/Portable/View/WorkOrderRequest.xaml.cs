using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class WorkOrderRequest : ContentPage
    {
        public WorkOrderRequest(int bid)
        {
            InitializeComponent();
            this.BindingContext = new WorkOrderRequestViewModal(bid);
        }
    }
}
