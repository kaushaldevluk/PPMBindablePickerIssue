using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class FCASystem : ContentPage
    {
        
        public FCASystem(int id)
        {
            
            InitializeComponent();
            this.BindingContext = new FCASystemViewModal(id);
        }
    }
}
