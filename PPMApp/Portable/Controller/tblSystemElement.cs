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
    //SystemElement
    public class tblSystemElement
    {
        private SQLiteConnection _connection;
        
        public tblSystemElement()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<SystemElement> GetAll()
        {
            if((from t in _connection.Table<SystemElement>() select t).ToList().Count == 0)
            {
                List<SystemElement> SystemElementList = new List<SystemElement>();
                SystemElement SE = new SystemElement();
                SE.SystemElementID = 0;
                SE.SystemElementName = "No Record Found";
                SystemElementList.Add(SE);

                SE = new SystemElement();
                SE.SystemElementID = 1;
                SE.SystemElementName = "My System Element";
                SystemElementList.Add(SE);
                return SystemElementList;
            }

            return (from t in _connection.Table<SystemElement>() select t).ToList();
        }
        public IEnumerable<SystemElement> NotUploaded()
        {
            return (from t in _connection.Table<SystemElement>() select t).Where(t => t.issupload == false).ToList();
        }
        public SystemElement Get(int ID)
        {
            return _connection.Table<SystemElement>().FirstOrDefault(t => t.SystemElementID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<SystemElement>(id);
        }
        public void Update(SystemElement s)
        {
            _connection.Update(s);
        }
        public void Add(SystemElement s)
        {

            _connection.Insert(s);
        }
    }
}
