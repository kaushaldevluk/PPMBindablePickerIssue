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
    public class tblMaterial
    {
        private SQLiteConnection _connection;

        public tblMaterial()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<Material> GetAll()
        {
            if ((from t in _connection.Table<Material>() select t).ToList().Count ==0)
            {
                List<Material> MaterialList = new List<Material>();
                Material MAT = new Material();
                MAT.MaterialID = 0;
                MAT.MaterialName = "No Record Found";
                MaterialList.Add(MAT);
                return MaterialList;
            }
            return (from t in _connection.Table<Material>() select t).ToList();
        }
        public IEnumerable<Material> NotUploaded()
        {
            return (from t in _connection.Table<Material>() select t).Where(t => t.issupload == false).ToList();
        }
        public Material Get(int ID)
        {
            return _connection.Table<Material>().FirstOrDefault(t => t.MaterialID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<Material>(id);
        }
        public void Update(Material mat)
        {
            _connection.Update(mat);
        }
        public void Add(Material mat)
        {

            _connection.Insert(mat);
        }
    }
}
