
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
    public class tblJobStatus
    {
        private SQLiteConnection _connection;

        public tblJobStatus()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public IList<JobStatus> GetAll()
        {
            if ((from t in _connection.Table<JobStatus>() select t).ToList().Count == 0)
            {
                tblJobStatus _tblJobStatus = new tblJobStatus();
                JobStatus _jobstatus = new JobStatus();
                _jobstatus.JobStatusId = 1;
                _jobstatus.StatusName = "Proposal (Before)";
                _tblJobStatus.Add(_jobstatus);

                _jobstatus = new JobStatus();
                _jobstatus.JobStatusId = 2;
                _jobstatus.StatusName = "Active (Progress)";
                _tblJobStatus.Add(_jobstatus);

                _jobstatus = new JobStatus();
                _jobstatus.JobStatusId = 3;
                _jobstatus.StatusName = "Post-Construction (After)";
                _tblJobStatus.Add(_jobstatus);

                _jobstatus = new JobStatus();
                _jobstatus.JobStatusId = 4;
                _jobstatus.StatusName = "Other:";
                _tblJobStatus.Add(_jobstatus);
            }
            return (from t in _connection.Table<JobStatus>() select t).ToList();
        }
        public IEnumerable<JobStatus> NotUploaded()
        {
            return (from t in _connection.Table<JobStatus>() select t).Where(t => t.issupload == false).ToList();
        }
        public JobStatus Get(int ID)
        {
            return _connection.Table<JobStatus>().FirstOrDefault(t => t.JobStatusId == ID);
        }
        public void Delete(int id)
        {
            _connection.Delete<JobStatus>(id);
        }
        public void Update(JobStatus js)
        {
            _connection.Update(js);
        }
        public void Add(JobStatus js)
        {
            _connection.Insert(js);
        }
    }
}
