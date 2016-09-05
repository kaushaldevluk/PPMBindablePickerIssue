using Portable;
using PPMApp.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite.Net;
using System.IO;
using Portable.Controller;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace PPMApp.iOS
{
    class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() {

        }
        public SQLiteConnection GetConnection()
        {
            //throw new NotImplementedException();
            var fileName = "PPMApp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}
