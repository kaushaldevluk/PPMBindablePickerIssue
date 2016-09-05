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
    public class tblSystemType
    {
        private SQLiteConnection _connection;

        public tblSystemType()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<SystemType> GetAll()
        {
            
            if ((from t in _connection.Table<SystemType>() select t).ToList().Count == 0)
            {
                List<SystemType> st = new List<SystemType>();
                st.Add(
                    new SystemType { SystemElementID = 0, SystemElementTypeName="No Record Found" }
                    );
                //return new SystemType { SystemTypeID = 0, SystemElementTypeName = "" }
                return st;
            }
            return (from t in _connection.Table<SystemType>() select t).ToList();
        }
        public IEnumerable<SystemType> NotUploaded()
        {
            return (from t in _connection.Table<SystemType>() select t).Where(t => t.issupload == false).ToList();
        }
        public SystemType Get(int ID)
        {
            return _connection.Table<SystemType>().FirstOrDefault(t => t.SystemTypeID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<SystemType>(id);
        }
        public void Update(SystemType s)
        {
            _connection.Update(s);
        }
        public void Add(SystemType s)
        {

            _connection.Insert(s);
        }
    }
}
