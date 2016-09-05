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
    public class tblProposalCheckListPitchedRoof
    {
        private SQLiteConnection _connection;

        public tblProposalCheckListPitchedRoof()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<ProposalCheckListPitchedRoof> GetAll()
        {
            return (from t in _connection.Table<ProposalCheckListPitchedRoof>() select t).ToList();
        }
        public IEnumerable<ProposalCheckListPitchedRoof> NotUploaded()
        {
            return (from t in _connection.Table<ProposalCheckListPitchedRoof>() select t).Where(t => t.issupload == false).ToList();
        }
        public ProposalCheckListPitchedRoof Get(int ID)
        {
            return _connection.Table<ProposalCheckListPitchedRoof>().FirstOrDefault(t => t.ProposalCheckPitchedRoofID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<ProposalCheckListPitchedRoof>(id);
        }
        public void Update(ProposalCheckListPitchedRoof p)
        {
            _connection.Update(p);
        }
        public void Add(ProposalCheckListPitchedRoof p)
        {

            _connection.Insert(p);
        }
    }
}
