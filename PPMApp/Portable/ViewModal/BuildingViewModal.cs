using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.Common.DataAnnotations;

namespace Portable
{
    public class BuildingViewModal : NotifyPropertyChangedBase
    {
        private string clientName;
        private string institution = "";
        private string building = "";
        private string job = "";
        private string status = "";
        private string photo = "";
        private string detail = "";

        [DisplayOptions(Header = "Client Name", PlaceholderText = "Client Name", Position = 1)]
        [DataSourceKey("ClientName")]
        public string ClientName
        {
            get
            {
                return this.clientName;
            }
            set
            {
                if (this.clientName != value)
                {
                    this.clientName = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DisplayOptions(Header = "Institution", PlaceholderText = "Institution", Position = 2)]
        [DataSourceKey("Institution")]
        public string Institution
        {
            get
            {
                return this.institution;
            }
            set
            {
                if (this.institution != value)
                {
                    this.institution = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DisplayOptions(Header = "Building", PlaceholderText = "Building", Position = 3)]
        [DataSourceKey("Building")]
        public string Building
        {
            get
            {
                return this.building;
            }
            set
            {
                if (this.building != value)
                {
                    this.building = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DisplayOptions(Header = "Job", PlaceholderText = "Job", Position = 4)]
        [DataSourceKey("Job")]
        public string Job
        {
            get
            {
                return this.job;
            }
            set
            {
                if (this.job != value)
                {
                    this.job = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DisplayOptions(Header = "Status", PlaceholderText = "Status", Position = 5)]
        [DataSourceKey("Status")]
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                if (this.status != value)
                {
                    this.status = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DisplayOptions(Header = "Photo", PlaceholderText = "Photo", Position = 6)]        
        public string Photo
        {
            get
            {
                return this.photo;
            }
            set
            {
                if (this.photo != value)
                {
                    this.photo = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DisplayOptions(Header = "Detail", PlaceholderText = "Detail", Position = 7)]
        public string Detail
        {
            get
            {
                return this.detail;
            }
            set
            {
                if (this.detail != value)
                {
                    this.detail = value;
                    this.OnPropertyChanged();
                }
            }
        }

    }
}
