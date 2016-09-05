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
    public class tblLocation
    {
        private SQLiteConnection _connection;

        public tblLocation()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<Location> GetAll()
        {
            return (from t in _connection.Table<Location>() select t).ToList();
        }
        public IEnumerable<Location> NotUploaded()
        {
            return (from t in _connection.Table<Location>() select t).Where(t => t.issupload == false).ToList();
        }
        public Location Get(int ID)
        {
            return _connection.Table<Location>().FirstOrDefault(t => t.LocationId == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<Location>(id);
        }
        public void Update(Location loc)
        {
            _connection.Update(loc);
        }
        public int Add(Location loc)
        {
            _connection.Insert(loc);
            return loc.LocationId;
        }

        public List<LocationListModal> LocationViewList()
        {

            //var q = _connection.Query<LocationListModal>("SELECT Location.LocationId, Client.ID, buildingtype.BuildingTypeName, Client.Name, Location.issupload FROM Location INNER JOIN buildingtype ON location.buildingtypeid = buildingtype.buildingtypeid INNER JOIN client ON location.clientid = client.ID").ToList();
            List<LocationListModal> llm = new List<LocationListModal>();
            List<Location> loc = (from t in _connection.Table<Location>() select t).ToList();
            tblBuildingType btype = new tblBuildingType();
            tblClient client = new tblClient();
            foreach (Location l in loc)
            {
                llm.Add(new LocationListModal { LocationId = l.LocationId, sync = l.issupload, BuildingName = btype.GetName(l.BuildingTypeID), ClientID = l.ClientID, ClientName =client.GetName(l.ClientID) });
            }
            //llm.Add(new LocationListModal { LocationId = 1, sync = true, BuildingName = "Building 1", ClientID = 1, ClientName = "Kaushal" });

            return llm;
            //(from LocationId in Location,
            //from ClientID in Client)
            //return q;
                //(x => new LocationListModal { LocationId = x.locationid, ClientID = x.clientid, BuildingName = x.buildingtypename, ClientName = x.clientname });
        }


    }
}
