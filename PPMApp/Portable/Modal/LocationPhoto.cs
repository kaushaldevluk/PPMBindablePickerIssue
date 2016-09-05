using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class LocationPhoto
    {
        [PrimaryKey, AutoIncrement]
        public int LocationPhotoID { get; set; }
        public string Photo { get; set; }
        [Default(value: 0)]
        public int LocationID { get; set; }
        public string PhotoDescription { get; set; }
        
        public DateTime PhotoUploadedDate { get; set; }
        public int BuildingID { get; set; }
        [Default(value: 0)]
        public int BuildingDeficiencyRepairID { get; set; }
        [Default(value: 0)]
        public int buildingWorkOrderID { get; set; }
        [Default(value: 0)]
        public int WorkOrderFollowUpID { get; set; }
        [Default(value: 0)]
        public int FacilityID { get; set; }
        [Default(value: 0)]
        public int WorkOrderRequestID { get; set; }
        [Default(value: 0)]
        public int DeficiencyRepairID { get; set; }

        [Default(value: 0)]
        public int ProjectBeforeID { get; set; }
        [Default(value: 0)]
        public int ProjectActiveID { get; set; }
        [Default(value: 0)]
        public int ProjectAfterID { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
