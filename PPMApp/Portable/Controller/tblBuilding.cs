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
    public class tblBuilding
    {
        private SQLiteConnection _connection;

        public tblBuilding()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();            
        }
        public IEnumerable<Building> GetAll()
        {
            return (from t in _connection.Table<Building>() select t).ToList();
        }
        public IEnumerable<Building> NotUploaded()
        {
            return (from t in _connection.Table<Building>() select t).Where(t => t.issupload == false).ToList();
        }
        public Building Get(int ID)
        {
            return _connection.Table<Building>().FirstOrDefault(t => t.BuildingID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<Building>(id);
        }
        public void Update(Building building)
        {
            _connection.Update(building);
        }
        public int Add(Building building)
        {

            _connection.Insert(building);
            return building.BuildingID;
        }
    }
}
