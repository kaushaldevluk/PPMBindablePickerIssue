using Portable.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.Input.DataForm;
using Xamarin.Forms;

namespace Portable
{
    public partial class StartPage : ContentPage
    {
        tblClient Client = new tblClient();
        private PPMAppDB _database;
        public StartPage(PPMAppDB database)
        {
            InitializeComponent();
            Title = "Client";
            _database = database;
            this.dataForm.Source = Client;
            this.dataForm.ValidationMode = ValidationMode.OnLostFocus;
            this.dataForm.CommitMode = CommitMode.Manual;
            
            this.dataForm.RegisterEditor("Name", EditorType.TextEditor);


            var toolbarItem = new ToolbarItem
            {
                Name = "Add",
                Command = new Command(() => Navigation.PushAsync(new AddBuilding()))
            };

            ToolbarItems.Add(toolbarItem);
            NavigationPage.SetHasNavigationBar(this, true);

            //this.dataForm.RegisterEditor("ContactNo", EditorType.IntegerEditor);
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
            Client = new tblClient();
            this.dataForm.Source = Client;
        }
    }
}