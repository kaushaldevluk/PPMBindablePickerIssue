using Portable.Modal;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Portable.Controller
{
    public class tblClient
    {
        private SQLiteConnection _connection;

        public tblClient()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<Client> GetAll()
        {
            return (from t in _connection.Table<Client>() select t).ToList();
        }
        public IEnumerable<Client> NotUploaded()
        {
            return (from t in _connection.Table<Client>() select t).Where(t => t.issupload == false).ToList();
        }
        public Client Get(int ID)
        {
            return _connection.Table<Client>().FirstOrDefault(t => t.ID == ID);
        }
        public string GetName(int ID)
        {
            Client c =  _connection.Table<Client>().FirstOrDefault(t => t.ID == ID);
            return (c == null ? "": c.Name);
        }

        public void Delete(int id)
        {
            _connection.Delete<Client>(id);
        }
        public void Update(Client c)
        {
            _connection.Update(c);
        }
        public void Add(Client c)
        {
            _connection.Insert(c);
        }
    }
}
