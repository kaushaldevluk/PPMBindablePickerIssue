using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class LocationView : ContentPage
    {
        public LocationView()
        {
            InitializeComponent();
            this.BindingContext = new LocationViewModel();           
        }
        
    }
}
