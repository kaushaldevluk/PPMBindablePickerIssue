using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portable.ViewModal;
using Xamarin.Forms;

namespace Portable
{
    public partial class ProposalChecklistFlatRoof : ContentPage
    {
        public ProposalChecklistFlatRoof(int BID)
        {
            InitializeComponent();
            this.BindingContext = new ProposalChecklistFlatRoofViewModal(BID);
        }
    }
}
