using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class FirstScreen : ContentPage
    {
        public FirstScreen()
        {
            InitializeComponent();
            this.BindingContext = new FirstScreenViewModal();
        }
    }
}
