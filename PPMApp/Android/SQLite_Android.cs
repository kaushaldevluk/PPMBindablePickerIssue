using System;
using Android.OS;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;
using PPMApp.Android;
using Portable;
using Portable.Controller;

[assembly: Dependency(typeof(SQLite_Android))]
namespace PPMApp.Android
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() {

        }
        public SQLiteConnection GetConnection()
        {
            var fileName = "PPMApp.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}