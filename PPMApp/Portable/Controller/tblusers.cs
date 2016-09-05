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
    public class tblusers
    {
        private SQLiteConnection _connection;

        public tblusers()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<users> GetAll()
        {
            return (from t in _connection.Table<users>() select t).ToList();
        }
        public IEnumerable<users> NotUploaded()
        {
            return (from t in _connection.Table<users>() select t).Where(t => t.issupload == false).ToList();
        }
        public users Get(int ID)
        {
            return _connection.Table<users>().FirstOrDefault(t => t.userid == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<users>(id);
        }
        public void Update(users users)
        {
            _connection.Update(users);
        }
        public void Add(users users)
        {

            _connection.Insert(users);
        }
    }
}
