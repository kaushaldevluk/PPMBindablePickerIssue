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
    public class tblBuildingType
    {
        private SQLiteConnection _connection;

        public tblBuildingType()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<BuildingType> GetAll()            
        {
            if ((from t in _connection.Table<BuildingType>() select t).ToList().Count == 0)
            {
                tblBuildingType tblbt = new tblBuildingType();
                BuildingType bt = new BuildingType();
                bt.BuildingTypeName = "Church";
                tblbt.Add(bt);

                bt = new BuildingType();                
                bt.BuildingTypeName = "School";
                tblbt.Add(bt);

                bt = new BuildingType();                
                bt.BuildingTypeName = "Residence";
                tblbt.Add(bt);

                bt = new BuildingType();                
                bt.BuildingTypeName = "Gym/Auditorium";
                tblbt.Add(bt);

                bt = new BuildingType();                
                bt.BuildingTypeName = "Other:";
                tblbt.Add(bt);
            }
                return (from t in _connection.Table<BuildingType>() select t).ToList();
        }
        public IEnumerable<BuildingType> NotUploaded()
        {
            return (from t in _connection.Table<BuildingType>() select t).Where(t => t.issupload == false).ToList();
        }
        public BuildingType Get(int ID)
        {
            return _connection.Table<BuildingType>().FirstOrDefault(t => t.BuildingTypeID == ID);
        }

        public string GetName(int ID)
        {
            BuildingType btype =_connection.Table<BuildingType>().FirstOrDefault(t => t.BuildingTypeID == ID);
            return (btype== null ?  "": btype.BuildingTypeName);
        }
        public void Delete(int id)
        {
            _connection.Delete<BuildingType>(id);
        }
        public void Update(BuildingType bt)
        {
            _connection.Update(bt);
        }
        public int Add(BuildingType bt)
        {
            _connection.Insert(bt);
            return bt.BuildingTypeID;

        }
    }
}
