using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Portable.Modal;
namespace Portable.Controller
{
    public class tblLocationPhoto
    {
        private SQLiteConnection _connection;

        public tblLocationPhoto()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<LocationPhoto> GetAll()
        {
            return (from t in _connection.Table<LocationPhoto>() select t).ToList();
        }
        public IEnumerable<LocationPhoto> NotUploaded()
        {
            return (from t in _connection.Table<LocationPhoto>() select t).Where(t => t.issupload == false).ToList();
        }
        public LocationPhoto Get(int ID)
        {
            return _connection.Table<LocationPhoto>().FirstOrDefault(t => t.LocationPhotoID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<LocationPhoto>(id);
        }
        public void Update(LocationPhoto lp)
        {
            _connection.Update(lp);
        }
        public int Add(LocationPhoto lp)
        {
            _connection.Insert(lp);
            return lp.LocationPhotoID;
        }
    }
}
