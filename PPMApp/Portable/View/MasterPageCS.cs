using System.Collections.Generic;

using Xamarin.Forms;

namespace Portable
{
    public class MasterPageCS : ContentPage
    {
        public ListView ListView { get { return listView; } }

        ListView listView;
        public MasterPageCS()
        {
            var masterPageItems = new List<MasterPageItem>();
            BackgroundImage = "bg.jpg";
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Add Building",
                IconSource = "",
                TargetType = typeof(LocationView)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Building List",
                IconSource = "",
                TargetType = typeof(LocationList)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Sync with Server",
                IconSource = "",
                TargetType = typeof(BuildingListPage)
            });

            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None,
                BackgroundColor = Color.Black,
                RowHeight = 80,
                Margin = 0,               
            };

            //Padding = new Thickness(0, 40, 0, 0);
            //Icon = "hamburger.png";
            Title = "PPM";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Black,
                //Opacity=0.7,
                Children = {
                    listView
                }
            };
        }
    }
}
