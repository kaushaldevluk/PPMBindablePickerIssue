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
    public class tblInstitutions
    {
        private SQLiteConnection _connection;

        public tblInstitutions()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<Institutions> GetAll()
        {
            return (from t in _connection.Table<Institutions>() select t).ToList();
        }
        public IEnumerable<Institutions> NotUploaded()
        {
            return (from t in _connection.Table<Institutions>() select t).Where(t => t.issupload == false).ToList();
        }
        public Institutions Get(int ID)
        {
            return _connection.Table<Institutions>().FirstOrDefault(t => t.InstitutionID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<Institutions>(id);
        }
        public void Update(Institutions i)
        {
            _connection.Update(i);
        }
        public void Add(Institutions i)
        {
            _connection.Insert(i);
        }
    }
}
