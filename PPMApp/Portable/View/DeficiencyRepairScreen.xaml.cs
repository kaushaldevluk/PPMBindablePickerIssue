using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class DeficiencyRepairScreen : ContentPage
    {
        public DeficiencyRepairScreen(int BuildingID)
        {
            InitializeComponent();
            this.BindingContext = new DeficiencyRepairScreenViewModal(BuildingID);
        }
    }
}
