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
    public class tblBuildingDeficiencyRepair
    {
        private SQLiteConnection _connection;

        public tblBuildingDeficiencyRepair()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<BuildingDeficiencyRepair> GetAll()
        {
            return (from t in _connection.Table<BuildingDeficiencyRepair>() select t).ToList();
        }
        public IEnumerable<BuildingDeficiencyRepair> NotUploaded()
        {
            return (from t in _connection.Table<BuildingDeficiencyRepair>() select t).Where(t => t.issupload == false).ToList();
        }
        public BuildingDeficiencyRepair Get(int ID)
        {
            return _connection.Table<BuildingDeficiencyRepair>().FirstOrDefault(t => t.BuildingDeficiencyRepairID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<BuildingDeficiencyRepair>(id);
        }
        public void Update(BuildingDeficiencyRepair buildingRepair)
        {
            _connection.Update(buildingRepair);
        }
        public int Add(BuildingDeficiencyRepair buildingRepair)
        {

            _connection.Insert(buildingRepair);
            return buildingRepair.BuildingDeficiencyRepairID;
        }
    }
}
