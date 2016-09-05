using Portable.Controller;
using System;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.Input.DataForm;
using Xamarin.Forms;

namespace Portable
{
    public partial class BuildingEntryPage : ContentPage
    {
        BuildingViewModal bentry = new BuildingViewModal();
        private PPMAppDB _database;
        public BuildingEntryPage(PPMAppDB database)
        {
            InitializeComponent();
            Title = "Add Building";
            _database = database;
            this.dataForm.Source = bentry;
            this.dataForm.ValidationMode = ValidationMode.OnLostFocus;
            this.dataForm.CommitMode = CommitMode.Manual;
            this.dataForm.PropertyDataSourceProvider = new BuildingEntryDSP();  
                      
            this.dataForm.RegisterEditor("ClientName", EditorType.PickerEditor);
            this.dataForm.RegisterEditor("Institution", EditorType.PickerEditor);
            this.dataForm.RegisterEditor("Building", EditorType.PickerEditor);
            this.dataForm.RegisterEditor("Job", EditorType.PickerEditor);
            this.dataForm.RegisterEditor("Status", EditorType.PickerEditor);
            this.dataForm.RegisterEditor("Photo",EditorType.TextEditor);
            this.dataForm.RegisterEditor("Detail", EditorType.TextEditor);

            var positive = "CCFF00";
            var negative = "FF004C";

            var style = new DataFormEditorStyle
            {
                Background = new Background
                {
                    Fill = Color.Transparent,
                    StrokeColor = Color.FromHex(positive),
                    StrokeWidth = 1
                    //StrokeLocation = Location.Bottom
                },
                HeaderFontSize = 15,
                HeaderForeground = Color.White,
                FeedbackFontSize = 10,
                //PositiveFeedbackImage = ImageSource.FromFile("success.png"),
                NegativeFeedbackForeground = Color.FromHex(negative),
                NegativeFeedbackBackground = new Background
                {
                    Fill = Color.FromHex(50 + negative),
                    StrokeColor = Color.FromHex(negative),
                    StrokeWidth = 2
                    //StrokeLocation = Location.All
                },
                Height = 60,
                FeedbackImageSize = new Size(10, 10),                               
            };

            dataForm.EditorStyle = style;
            dataForm.BackgroundColor = Color.FromHex("3D6978");

            var toolbarItem = new ToolbarItem
            {
                Name = "See All",
                Command = new Command(() => Navigation.PushAsync(new BuildingListPage()))
            };

            ToolbarItems.Add(toolbarItem);

            NavigationPage.SetHasNavigationBar(this, true);

        }
        private async void DataFormValidationCompleted(object sender, FormValidationCompletedEventArgs e)
        {
            this.dataForm.FormValidationCompleted -= this.DataFormValidationCompleted;
            if (e.IsValid)
            {
                await this.DisplayAlert("Success", "Client Detail Save Successfully.", "OK");
            }
            else
            {
                await this.DisplayAlert("Fail", string.Format("There are some invalid fields."), "OK");
            }
        }

        private void CommitButtonButtonClicked(object sender, EventArgs e)
        {
            this.dataForm.FormValidationCompleted += this.DataFormValidationCompleted;
            this.dataForm.CommitAll();
            bentry = new BuildingViewModal();
            this.dataForm.Source = bentry;
        }
    }
}
