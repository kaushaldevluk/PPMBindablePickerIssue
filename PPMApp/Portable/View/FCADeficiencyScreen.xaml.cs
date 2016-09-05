using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class FCADeficiencyScreen : ContentPage
    {
        public FCADeficiencyScreen(int bid)
        {
            InitializeComponent();
            this.BindingContext = new FCADeficiencyViewModal(bid);
        }
    }
}
