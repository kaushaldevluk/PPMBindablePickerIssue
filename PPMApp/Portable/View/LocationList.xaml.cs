using Portable.Controller;
using Portable.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Portable
{
    public partial class LocationList : ContentPage
    {

        private tblLocation _tblLocation;
        public LocationList()
        {
            InitializeComponent();
            //this.BindingContext = new LocationListViewModal();
            Title = "Buildings";

            var toolbarItem = new ToolbarItem
            {
                Name = "Add New",
                Command = new Command(() => Navigation.PushAsync(new LocationView()))
            };
            ToolbarItems.Add(toolbarItem);
            NavigationPage.SetHasNavigationBar(this, true);

            listView.ItemsSource = this.GetSource();

            //switch (Device.OS)
            //{
            //    case TargetPlatform.iOS:
            //        listView.LayoutDefinition.ItemLength = 60;
            //        listView.BackgroundColor = Color.Transparent;
            //        break;
            //    default:
            //        listView.LayoutDefinition.ItemLength = -1;
            //        listView.BackgroundColor = Color.Transparent;
            //        break;
            //}
            //listView.GroupDescriptors.Clear();

            //listView.GroupDescriptors.Add(new PropertyGroupDescriptor
            //{
            //    PropertyName = "Location"
            //});

            listView.IsPullToRefreshEnabled = true;
        }

        private System.Collections.IEnumerable GetSource()
        {
            var items = new List<LocationListModal>();
            //for (int i = 0; i < count; i++)
            //{
            //    items.Add(new Client { Name = string.Format("Building {0}", i) });
            //}
            //items.Add(new Demo { Name = "Albany", Location= "City", sync=true });
            //items.Add(new Demo { Name = "Auburn", Location = "City", sync = true });
            //items.Add(new Demo { Name = "Baldwin", Location = "CDP", sync = true });
            //items.Add(new Demo { Name = "Bay Shore", Location = "CDP", sync = true });
            //items.Add(new Demo { Name = "Binghamton", Location = "City", sync = true });
            //items.Add(new Demo { Name = "Brentwood", Location = "CDP", sync = true });
            //items.Add(new Demo { Name = "Brighton", Location = "Town", sync = true });
            //items.Add(new Demo { Name = "Buffalo", Location = "City", sync = true });
            //items.Add(new Demo { Name = "Centereach", Location = "CDP", sync = true });
            //items.Add(new Demo { Name = "Kingston", Location = "City", sync = true });
            //items.Add(new Modal.Location { Name = "Albany", Location = "City", sync = true });
            _tblLocation = new tblLocation();
            items = _tblLocation.LocationViewList();
            return items;
        }

        private void IncreaseButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button.BindingContext as Demo;
            //item.Value++;
            listView.EndItemSwipe();
        }

        private void DecreaseButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button.BindingContext as Demo;
            //if (item.Value > 0)
            //{
            //    item.Value--;
            //}

            listView.EndItemSwipe();
        }
    }
}
