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
    public class tblJobType
    {
        private SQLiteConnection _connection;

        public tblJobType()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<JobType> GetAll()
        {
            if ((from t in _connection.Table<JobType>() select t).ToList().Count == 0)
            {
                tblJobType dbjt = new tblJobType();
                JobType jt = new JobType();
                jt.JobTypeId = 1;
                jt.JobTypeName = "Exterior Restoration";
                dbjt.Add(jt);

                jt = new JobType();
                jt.JobTypeId = 2;
                jt.JobTypeName = "Interior/GC";
                dbjt.Add(jt);

                jt = new JobType();
                jt.JobTypeId = 3;
                jt.JobTypeName = "FCA/Planning";
                dbjt.Add(jt);

                jt = new JobType();
                jt.JobTypeId = 4;
                jt.JobTypeName = "Facility Maintenance";
                dbjt.Add(jt);

                jt = new JobType();
                jt.JobTypeId = 5;
                jt.JobTypeName = "Other:";
                dbjt.Add(jt);
            }
            return (from t in _connection.Table<JobType>() select t).ToList();
        }
        public IEnumerable<JobType> NotUploaded()
        {
            return (from t in _connection.Table<JobType>() select t).Where(t => t.issupload == false).ToList();
        }
        public JobType Get(int ID)
        {
            return _connection.Table<JobType>().FirstOrDefault(t => t.JobTypeId == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<JobType>(id);
        }
        public void Update(JobType jt)
        {
            _connection.Update(jt);
        }
        public void Add(JobType jt)
        {
            _connection.Insert(jt);
            
        }
    }
}
