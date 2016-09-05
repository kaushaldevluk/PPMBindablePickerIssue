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
    public class tblBuildingWorkOrder
    {
        private SQLiteConnection _connection;

        public tblBuildingWorkOrder()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<BuildingWorkOrder> GetAll()
        {
            return (from t in _connection.Table<BuildingWorkOrder>() select t).ToList();
        }
        public IEnumerable<BuildingWorkOrder> NotUploaded()
        {
            return (from t in _connection.Table<BuildingWorkOrder>() select t).Where(t => t.issupload == false).ToList();
        }
        public BuildingWorkOrder Get(int ID)
        {
            return _connection.Table<BuildingWorkOrder>().FirstOrDefault(t => t.WorkOrderID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<BuildingWorkOrder>(id);
        }
        public void Update(BuildingWorkOrder buildingWork)
        {
            _connection.Update(buildingWork);
        }
        public int Add(BuildingWorkOrder buildingWork)
        {
            _connection.Insert(buildingWork);
            return buildingWork.WorkOrderID;
        }
    }
}
