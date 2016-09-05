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
    public class tblBuildingSystem
    {
        private SQLiteConnection _connection;

        public tblBuildingSystem()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<BuildingSystem> GetAll()
        {
            if ((from t in _connection.Table<BuildingSystem>() select t).ToList().Count == 0)
            {
                tblBuildingSystem tblbs = new tblBuildingSystem();
                BuildingSystem bs = new BuildingSystem();
                bs.BuildingSystemName = "Structural";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "Exterior Walls";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "Roofing";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "Interior Finishes";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "Plumbing";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "HVAC";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "Electrical";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "Life Safety";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "FFE";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);

                bs = new BuildingSystem();
                bs.BuildingSystemName = "Site Improvements";
                bs.createon = DateTime.Now;
                tblbs.Add(bs);
            }
            return (from t in _connection.Table<BuildingSystem>() select t).ToList();
        }
        public IEnumerable<BuildingSystem> NotUploaded()
        {
            return (from t in _connection.Table<BuildingSystem>() select t).Where(t => t.issupload == false).ToList();
        }
        public BuildingSystem Get(int ID)
        {
            return _connection.Table<BuildingSystem>().FirstOrDefault(t => t.BuildingSystemID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<BuildingSystem>(id);
        }
        public void Update(BuildingSystem buildingSys)
        {
            _connection.Update(buildingSys);
        }
        public void Add(BuildingSystem buildingSys)
        {

            _connection.Insert(buildingSys);
        }
    }
}
