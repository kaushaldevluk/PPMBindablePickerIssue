using Portable.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage(int id,string name)
        {
            InitializeComponent();
            Title = "Upload Image";
            this.BindingContext = new CameraViewModel(id, name);
        }
        
    }
}
