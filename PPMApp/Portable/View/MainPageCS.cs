using System;

using Xamarin.Forms;

namespace Portable
{
    public class MainPageCS : MasterDetailPage
    {
        MasterPageCS masterPage;
        public MainPageCS(Page page)
        {
            masterPage = new MasterPageCS();
            Master = masterPage;
            //Detail = new NavigationPage(new AddBuilding());
            Detail = new NavigationPage(page);
            //BackgroundImage = "bg.jpg";
            masterPage.ListView.ItemSelected += OnItemSelected;

            if (Device.OS == TargetPlatform.Windows)
            {
                //Master.Icon = "swap.png";
            }
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Hello ContentPage" }
            //    }
            //};
        }
        public MainPageCS()
        {
            
        }

        public void RedirectPage(Type page,string MyTitle= "",string MyIcon="")
        {
            //masterPage = new MasterPageCS();
            //Master = masterPage;
            //Detail = new NavigationPage(new AddBuilding());
            //Detail = new NavigationPage(page);

            //try {
                
            //    MasterPageItem item = new MasterPageItem
            //    {
            //        Title = MyTitle,
            //        IconSource = MyIcon,
            //        TargetType = page
            //    };
                

                
            //    if (item != null)
            //    {
            //        //masterPage = new MasterPageCS();
            //        //Master = masterPage;
            //        Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            //        IsPresented = false;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    DisplayAlert("Error", ex.Message, "Cancel");
            //}
            
            //BackgroundImage = "bg.jpg";
            //masterPage.ListView.ItemSelected += OnItemSelected;

            //if (Device.OS == TargetPlatform.Windows)
            //{
            //    //Master.Icon = "swap.png";
            //}
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
