using Portable.ViewModal;
using Xamarin.Forms;

namespace Portable
{
    public class AddBuilding : ContentPage
    {
            
       

        public AddBuilding()
        {
            //Setup();
            Title = "Location";
            BackgroundImage = "bg.jpg";
            this.BindingContext = new LocationViewModel();
           
            var toolbarItem = new ToolbarItem
            {
                Name = "See All",                
                Command = new Command(() => Navigation.PushAsync(new BuildingListPage()))
            };
            ToolbarItems.Add(toolbarItem);
            NavigationPage.SetHasNavigationBar(this, true);

            var lblClientName = new Label();
            lblClientName.Text = "Select Client: ";

            var PickClient = new Picker();
            
            PickClient.Items.Add("Select Client");
            PickClient.Items.Add("Client 1");
            PickClient.Items.Add("Client 2");
            PickClient.Items.Add("Client 3");
            PickClient.Items.Add("Client 4");
            PickClient.Items.Add("Client 5");
            PickClient.SelectedIndex = 0;

            var lblInstitutionName = new Label();
            lblInstitutionName.Text = "Select Institution: ";
            var pickIns = new Picker();
            pickIns.Items.Add("Select Institution");
            pickIns.Items.Add("Institution 1");
            pickIns.Items.Add("Institution 2");
            pickIns.Items.Add("Institution 3");
            pickIns.Items.Add("Institution 4");
            pickIns.Items.Add("Institution 5");
            pickIns.SelectedIndex = 0;

            var lblBuildingName = new Label();
            lblBuildingName.Text = "Select Building: ";

            var pickBuilding = new Picker();
            pickBuilding.Items.Add("Select Building");
            pickBuilding.Items.Add("Church");
            pickBuilding.Items.Add("School");
            pickBuilding.Items.Add("Residence");
            pickBuilding.Items.Add("Gym/Auditorium");
            pickBuilding.Items.Add("Other");
            pickBuilding.SelectedIndex = 0;

            var lblJobName = new Label();
            lblJobName.Text = "Select Job: ";
            var picJob = new Picker();
            picJob.Items.Add("Select Job");
            picJob.Items.Add("Exterior Restoration");
            picJob.Items.Add("FCA/ Planning");
            picJob.Items.Add("Facility Maintenance");            
            picJob.Items.Add("Other");
            picJob.SelectedIndex = 0;


            var button = new Button
            {
                Text = "Snap!",                
                BackgroundColor = Color.FromHex("00d0d2"),
                Opacity=0.7,
                //Command = new Command(o => ShouldTakePicture()),
            };




            PickClient.TextColor = Color.FromHex("00d0d2");
            pickIns.TextColor = Color.FromHex("00d0d2");
            pickBuilding.TextColor = Color.FromHex("00d0d2");
            picJob.TextColor = Color.FromHex("00d0d2");
            //PickClient.TextColor = Color.FromHex("00d0d2");
            //PickClient.TextColor = Color.FromHex("00d0d2");

            Content = new StackLayout
            {
                Spacing = 10,
                Padding = new Thickness(10),
                Children = { lblClientName, PickClient, lblInstitutionName, pickIns, lblBuildingName, pickBuilding, lblJobName, picJob, button }
            };
        }
        

       
    }
}
