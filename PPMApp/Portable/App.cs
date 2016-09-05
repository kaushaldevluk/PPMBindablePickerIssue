using Portable.Controller;

using Xamarin.Forms;

namespace Portable
{
    public class App : Application
    {
        public static PPMService ppmservice { get; private set; }
        public App()
        {
            // The root page of your application
            var database = new PPMAppDB();
            ppmservice = new PPMService(new RestService());
            //MainPage = new MainPageCS(new LocationView());
            //MainPage = new MainPageCS(new LocationList());
            // MainPage = new MainPageCS(new FCASystem());
            //MainPage = new MainPageCS(new FirstScreen()); 
            MainPage = new MainPageCS(new FirstScreen());


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
