using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class FacilityScreen : ContentPage
    {
        public FacilityScreen(int locid)
        {
            InitializeComponent();
            this.BindingContext = new FacilityViewModal(locid);
        }
    }
}
