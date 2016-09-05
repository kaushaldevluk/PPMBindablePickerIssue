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
    public class PPMAppDB
    {
        private SQLiteConnection _connection;
        public PPMAppDB()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Building>();
            _connection.CreateTable<BuildingDeficiencyRepair>();
            _connection.CreateTable<BuildingSystem>();
            _connection.CreateTable<BuildingWorkOrder>();
            _connection.CreateTable<BuildingType>();
            _connection.CreateTable<Client>();
            _connection.CreateTable<JobStatus>();
            _connection.CreateTable<JobType>();
            _connection.CreateTable<Labour>();
            _connection.CreateTable<Location>();
            _connection.CreateTable<LocationPhoto>();
            _connection.CreateTable<Material>();
            _connection.CreateTable<Project>();
            _connection.CreateTable<ProposalChecklistExteriorWalls>();
            _connection.CreateTable<ProposalCheckListFlatRoof>();
            _connection.CreateTable<ProposalCheckListPitchedRoof>();
            _connection.CreateTable<ServiceContract>();
            _connection.CreateTable<SystemElement>();
            _connection.CreateTable<SystemType>();
            _connection.CreateTable<users>();
            _connection.CreateTable<WorkOrderFollowUp>();           

        }

    }
}
