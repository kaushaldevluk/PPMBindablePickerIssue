using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class ProposalChecklistExteriorWallsScreen : ContentPage
    {
        public ProposalChecklistExteriorWallsScreen(int BuildingID)
        {
            InitializeComponent();
            this.BindingContext = new ProposalChecklistExteriorWallsViewModal(BuildingID);
        }
    }
}
