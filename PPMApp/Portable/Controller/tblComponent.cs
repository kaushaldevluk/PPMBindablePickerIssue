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
    public class tblComponent
    {
        private SQLiteConnection _connection;

        public tblComponent()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<Component> GetAll()
        {
            if ((from t in _connection.Table<Component>() select t).ToList().Count == 0)
            {
                List<Component> dbproject = new List<Component>();
                Component p = new Component();
                p.ComponentID = 0;
                p.ComponentName = "No Record Found";
                dbproject.Add(p);
                return dbproject;
            }
            return (from t in _connection.Table<Component>() select t).ToList();
        }
        public IEnumerable<Component> NotUploaded()
        {
            return (from t in _connection.Table<Component>() select t).Where(t => t.issupload == false).ToList();
        }
        public Component Get(int ID)
        {
            return _connection.Table<Component>().FirstOrDefault(t => t.ComponentID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<Component>(id);
        }
        public void Update(Component c)
        {
            _connection.Update(c);
        }
        public void Add(Component c)
        {
            _connection.Insert(c);
        }
    }
}
