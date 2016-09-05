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
    public class tblWorkOrderFollowUp
    {
        private SQLiteConnection _connection;

        public tblWorkOrderFollowUp()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<WorkOrderFollowUp> GetAll()
        {
            return (from t in _connection.Table<WorkOrderFollowUp>() select t).ToList();
        }
        public IEnumerable<WorkOrderFollowUp> NotUploaded()
        {
            return (from t in _connection.Table<WorkOrderFollowUp>() select t).Where(t => t.issupload == false).ToList();
        }
        public WorkOrderFollowUp Get(int ID)
        {
            return _connection.Table<WorkOrderFollowUp>().FirstOrDefault(t => t.WorkOrderFollowUpID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<WorkOrderFollowUp>(id);
        }
        public void Update(WorkOrderFollowUp WorkOrderFollowUp)
        {
            _connection.Update(WorkOrderFollowUp);
        }
        public int Add(WorkOrderFollowUp WorkOrderFollowUp)
        {
            _connection.Insert(WorkOrderFollowUp);
            return WorkOrderFollowUp.WorkOrderFollowUpID;
        }
    }
}
