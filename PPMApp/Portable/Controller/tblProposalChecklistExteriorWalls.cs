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
    public class tblProposalChecklistExteriorWalls
    {
        private SQLiteConnection _connection;

        public tblProposalChecklistExteriorWalls()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<ProposalChecklistExteriorWalls> GetAll()
        {
            return (from t in _connection.Table<ProposalChecklistExteriorWalls>() select t).ToList();
        }
        public IEnumerable<ProposalChecklistExteriorWalls> NotUploaded()
        {
            return (from t in _connection.Table<ProposalChecklistExteriorWalls>() select t).Where(t => t.issupload == false).ToList();
        }
        public ProposalChecklistExteriorWalls Get(int ID)
        {
            return _connection.Table<ProposalChecklistExteriorWalls>().FirstOrDefault(t => t.ProposalCheckExteriorWallsid == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<ProposalChecklistExteriorWalls>(id);
        }
        public void Update(ProposalChecklistExteriorWalls p)
        {
            _connection.Update(p);
        }
        public int Add(ProposalChecklistExteriorWalls p)
        {
            _connection.Insert(p);
            return p.ProposalCheckExteriorWallsid;
        }
    }
}
