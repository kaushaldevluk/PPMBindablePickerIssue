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
    public class tblProject
    {
        private SQLiteConnection _connection;

        public tblProject()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<Project> GetAll()
        {
            if ((from t in _connection.Table<Project>() select t).ToList().Count ==0)
            {

                List<Project> dbproject = new List<Project>();
                Project p = new Project();
                p.ProjectID = 0;
                p.ProjectName = "No Record Found";
                dbproject.Add(p);
                return dbproject;
            }
            return (from t in _connection.Table<Project>() select t).ToList();
        }
        public IEnumerable<Project> NotUploaded()
        {
            return (from t in _connection.Table<Project>() select t).Where(t => t.issupload == false).ToList();
        }
        public Project Get(int ID)
        {
            return _connection.Table<Project>().FirstOrDefault(t => t.ProjectID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<Project>(id);
        }
        public void Update(Project p)
        {
            _connection.Update(p);
        }
        public void Add(Project p)
        {
            _connection.Insert(p);
        }
    }
}
