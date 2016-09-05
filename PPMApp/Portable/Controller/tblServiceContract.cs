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
    //ServiceContract
    public class tblServiceContract
    {
        private SQLiteConnection _connection;

        public tblServiceContract()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<ServiceContract> GetAll()
        {
            if ((from t in _connection.Table<ServiceContract>() select t).ToList().Count == 0)
            {
                List<ServiceContract> dbproject = new List<ServiceContract>();
                ServiceContract p = new ServiceContract();
                p.ServiceContractID= 0;
                p.ServiceContractName = "No Record Found";
                dbproject.Add(p);
                return dbproject;
            }
            return (from t in _connection.Table<ServiceContract>() select t).ToList();
        }
        public IEnumerable<ServiceContract> NotUploaded()
        {
            return (from t in _connection.Table<ServiceContract>() select t).Where(t => t.issupload == false).ToList();
        }
        public ServiceContract Get(int ID)
        {
            return _connection.Table<ServiceContract>().FirstOrDefault(t => t.ServiceContractID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<ServiceContract>(id);
        }
        public void Update(ServiceContract s)
        {
            _connection.Update(s);
        }
        public void Add(ServiceContract s)
        {
            _connection.Insert(s);
        }
    }
}
