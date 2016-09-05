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
    public class tblLabour
    {
        private SQLiteConnection _connection;

        public tblLabour()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<Labour> GetAll()
        {
            if ((from t in _connection.Table<Labour>() select t).ToList().Count == 0)
            {
                List<Labour> dbproject = new List<Labour>();
                Labour p = new Labour();
                p.LabourID = 0;
                p.LabourName = "No Record Found";
                dbproject.Add(p);
                return dbproject;
            }
            return (from t in _connection.Table<Labour>() select t).ToList();
        }
        public IEnumerable<Labour> NotUploaded()
        {
            return (from t in _connection.Table<Labour>() select t).Where(t => t.issupload == false).ToList();
        }
        public Labour Get(int ID)
        {
            return _connection.Table<Labour>().FirstOrDefault(t => t.LabourID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<Labour>(id);
        }
        public void Update(Labour lb)
        {
            _connection.Update(lb);
        }
        public void Add(Labour lb)
        {
            _connection.Insert(lb);
        }
    }
}
