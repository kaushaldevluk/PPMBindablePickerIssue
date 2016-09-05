using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Portable.ViewModal
{
    public class FirstScreenViewModal
    {
        private ICommand _addnewcommand;

        private string _pendingupload { get; set; }
        public FirstScreenViewModal()
        {

        }

        public string PrndingUpload
        {
            get { return _pendingupload; }
            set { _pendingupload = value; }
        }

        public ICommand AddNewCommand
        {
            get
            {
                return _addnewcommand ?? (_addnewcommand = new Command(
                                                                           async () => await AddNew(),
                                                                           () => true));
            }
        }

        private async Task AddNew()
        {
            App.Current.MainPage = new MainPageCS(new LocationView());
        }
    }
}
