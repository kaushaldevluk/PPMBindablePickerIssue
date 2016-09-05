using Portable.Controller;
using Portable.Modal;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms.Labs.Mvvm;

namespace Portable.ViewModal
{
    [ViewType(typeof(LocationList))]
    public class LocationListViewModal : Xamarin.Forms.Labs.Mvvm.ViewModel, INotifyPropertyChanged
    {
        private tblLocation _tblLocation;
        public IList<LocationListModal> Items { get; set; }

        public LocationListViewModal()
        {
            _tblLocation = new tblLocation();
            Items = _tblLocation.LocationViewList();
        }
    }
}
