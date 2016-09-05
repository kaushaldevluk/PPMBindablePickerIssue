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
    public class tblProposalCheckListFlatRoof
    {
        private SQLiteConnection _connection;

        public tblProposalCheckListFlatRoof()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IEnumerable<ProposalCheckListFlatRoof> GetAll()
        {
            return (from t in _connection.Table<ProposalCheckListFlatRoof>() select t).ToList();
        }
        public IEnumerable<ProposalCheckListFlatRoof> NotUploaded()
        {
            return (from t in _connection.Table<ProposalCheckListFlatRoof>() select t).Where(t => t.issupload == false).ToList();
        }
        public ProposalCheckListFlatRoof Get(int ID)
        {
            return _connection.Table<ProposalCheckListFlatRoof>().FirstOrDefault(t => t.ProposalCheckListID == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<ProposalCheckListFlatRoof>(id);
        }
        public void Update(ProposalCheckListFlatRoof p)
        {
            _connection.Update(p);
        }
        public void Add(ProposalCheckListFlatRoof p)
        {
            _connection.Insert(p);
        }
    }
}
