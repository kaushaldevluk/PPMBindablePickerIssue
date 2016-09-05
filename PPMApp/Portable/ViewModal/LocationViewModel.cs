using Portable.Controller;
using Portable.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Media;

namespace Portable.ViewModal
{
    /// <summary>
    /// Class CameraViewModel.
    /// </summary>
    [ViewType(typeof(LocationView))]
    public class LocationViewModel : Xamarin.Forms.Labs.Mvvm.ViewModel, INotifyPropertyChanged
    {
        private ICommand _saveCommand;
        //private PPMAppDB _database;
        private tblLocation _tblLocation;
        private tblJobStatus _tblJobStatus;
        private tblJobType _tblJobType;
        private tblBuildingType _tblBuildingType;
        /// <summary>
        /// The _scheduler.
        /// </summary>
        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        /// <summary>
        /// The picture chooser.
        /// </summary>
        private Xamarin.Forms.Labs.Services.Media.IMediaPicker _mediaPicker;

        /// <summary>
        /// The image source.
        /// </summary>
        private ImageSource _imageSource;

        /// <summary>
        /// The video info.
        /// </summary>
        private string _videoInfo;

        /// <summary>
        /// The take picture command.
        /// </summary>
        private Command _takePictureCommand;

        /// <summary>
        /// The select picture command.
        /// </summary>
        private Command _selectPictureCommand;

        /// <summary>
        /// The select video command.
        /// </summary>
        private Command _selectVideoCommand;

        private string _status;

        public IList<Client> ClientList { get; set; }
        public IList<Institutions> InstitutionsList { get; set; }
        public IList<BuildingType> BuildingList { get; set; }
        public IList<JobType> JobTypeList { get; set; }
        public IList<JobStatus> JobStatusList { get; set; }

        public int ClientSelectedValue { get; set; }

        public string ClientStaticSelectedItem { get; set; }

        public int InsSelectedValue { get; set; }

        public string InsSelectedItem { get; set; }

        public int BuildingSelectedValue { get; set; }

        public string BuildingSelectedItem { get; set; }

        public int JobTypeSelectedValue { get; set; }

        public string JobTypeSelectedItem { get; set; }

        public int JobStatusSelectedValue { get; set; }

        public string JobStatusSelectedItem { get; set; }
        public string _JobStatus { get; set; }
        
        
        ////private CancellationTokenSource cancelSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationViewModel" /> class.
        /// </summary>
        /// 
        public LocationViewModel()
        {
            Setup();
            
            ClientList = new List<Client>()
            {
                //new Client
                //{
                //    Name = "Select Client",
                //    ID = 0,                    
                //},
                new Client
                {
                    Name="Client 1",
                    ID = 1,
                }                
            };

            InstitutionsList = new List<Institutions>()
            {
                //new Institutions
                //{
                //    InstitutionID = 0,
                //    ShortName = "Select Institutions",
                //},
                new Institutions
                {
                    InstitutionID = 1,
                    ShortName = "Institutions 1",
                }
            };
            //BuildingList = new List<Building>()
            //{
            //    new Building
            //    {
            //        BuildingID = 0,
            //        BuildingCode = "Select Institutions",
            //    },
            //    new Building
            //    {
            //        BuildingID = 1,
            //        BuildingCode = "Building 1",
            //    }
            //};

            //JobTypeList = new List<JobType>()
            //{
            //    //new JobType
            //    //{
            //    //    JobTypeId = 0,
            //    //    JobTypeName = "Select JobType"
            //    //},
            //    new JobType
            //    {
            //        JobTypeId = 1,
            //        JobTypeName = "JobType 1"
            //    }

            //};
            _tblJobType = new tblJobType();
            JobTypeList = _tblJobType.GetAll();
            _tblBuildingType = new tblBuildingType();
            BuildingList = _tblBuildingType.GetAll();
            _tblJobStatus = new tblJobStatus();
            JobStatusList = _tblJobStatus.GetAll();

        }
        public string PickBuilding
        {
            get
            {
                return "Select Building: ";
            }
        }

       

        public string PickJobType
        {
            get
            {
                return "Select Job Type: ";
            }
        }

        public string PickJobStatus
        {
            get
            {
                return "Select Job Status: ";
            }
        }

        public string PickInstitution
        {
            get
            {
                return "Select Institution: ";
            }
        }

        public string PickClient
        {
            get
            {
                return "Select Client: ";
            }
        }
        
        /// <summary>
        /// Gets or sets the image source.
        /// </summary>
        /// <value>The image source.</value>
        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                SetProperty(ref _imageSource, value);
            }
        }


       
        /// <summary>
        /// Gets or sets the video info.
        /// </summary>
        /// <value>The video info.</value>
        public string VideoInfo
        {
            get
            {
                return _videoInfo;
            }
            set
            {
                SetProperty(ref _videoInfo, value);
            }
        }

        public string JobStatus
        {
            get
            {
                return _JobStatus;
            }
            set
            {
                _JobStatus = value;
            }
        }
        
        /// <summary>
        /// Gets the take picture command.
        /// </summary>
        /// <value>The take picture command.</value>
        public Command TakePictureCommand
        {
            get
            {
                return _takePictureCommand ?? (_takePictureCommand = new Command(
                                                                       async () => await TakePicture(),
                                                                       () => true));
            }
        }

        /// <summary>
        /// Gets the select video command.
        /// </summary>
        /// <value>The select picture command.</value>
        public Command SelectVideoCommand
        {
            get
            {
                return _selectVideoCommand ?? (_selectVideoCommand = new Command(
                                                                       async () => await SelectVideo(),
                                                                       () => true));
            }
        }

        /// <summary>
        /// Gets the select picture command.
        /// </summary>
        /// <value>The select picture command.</value>
        public Command SelectPictureCommand
        {
            get
            {
                return _selectPictureCommand ?? (_selectPictureCommand = new Command(
                                                                           async () => await SelectPicture(),
                                                                           () => true));
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(
                                                                           async () => await SaveDetail(),
                                                                           () => true));
            }
        }

        public async Task SaveDetail()
        {
            //Setup();            
            try
            {
                Location loc = new Location();
                loc.ClientID = ClientSelectedValue;
                loc.InstitutionID = InsSelectedValue;
                loc.BuildingTypeID = BuildingSelectedValue;
                loc.JobTypeID = JobTypeSelectedValue;
                loc.JobStatusID = JobStatusSelectedValue;
                loc.JobDetail = JobStatus;
                loc.createon = DateTime.Now;
                loc.issupload = false;
                loc.isedit = false;
                _tblLocation = new tblLocation();
                
                _tblLocation.Add(loc);
                App.Current.MainPage = new MainPageCS(new CameraPage(loc.LocationId,"Location"));
                //_tblLocation.Add(loc);
                
                //await Navigation.PushAsync(cam);
                //cam = new CameraPage();
                //await Navigation.PopAsync();
                //await Navigation.PushModalAsync(new CameraPage());
                //new MainPageCS(new CameraPage());
                //MainPageCS main = new MainPageCS();
                //main.RedirectPage(typeof(CameraPage),"Upload Photos");
                //cam.Refresh();
                //try
                //{

                //    MasterPageItem item = new MasterPageItem
                //    {
                //        Title = "PPM",
                //        IconSource = "",
                //        TargetType = typeof(CameraPage)
                //    };

                //    if (item != null)
                //    {
                //        //masterPage = new MasterPageCS();
                //        //Master = masterPage;
                //        //(Page)Activator.CreateInstance(typeof(CameraPage))
                //        main.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CameraPage)));                        
                //    }
                //}
                //catch (Exception ex)
                //{
                //    await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
                //}

            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error !!",ex.Message,"Cancel");
            }
        }
        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status
        {
            get { return _status; }
            private set { SetProperty(ref _status, value); }
        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        private void Setup()
        {
           
            if (_mediaPicker != null)
            {
                return;
            }
            //System.NullReferenceException: IResolver has not been set.Please set it by calling Resolver.SetResolver(resolver) method.

            var device = Resolver.Resolve<IDevice>();

            ////RM: hack for working on windows phone? 
            _mediaPicker = DependencyService.Get<Xamarin.Forms.Labs.Services.Media.IMediaPicker>() ?? device.MediaPicker;
        }

        /// <summary>
        /// Takes the picture.
        /// </summary>
        /// <returns>Take Picture Task.</returns>
        private async Task<MediaFile> TakePicture()
        {
            Setup();

            ImageSource = null;

            return await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Status = t.Exception.InnerException.ToString();
                }
                else if (t.IsCanceled)
                {
                    Status = "Canceled";
                }
                else
                {
                    var mediaFile = t.Result;

                    ImageSource = ImageSource.FromStream(() => mediaFile.Source);

                    return mediaFile;
                }

                return null;
            }, _scheduler);
        }

        /// <summary>
        /// Selects the picture.
        /// </summary>
        /// <returns>Select Picture Task.</returns>
        private async Task SelectPicture()
        {
            Setup();

            ImageSource = null;
            try
            {
                var mediaFile = await _mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });
                ImageSource = ImageSource.FromStream(() => mediaFile.Source);
            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
            }
        }

        /// <summary>
        /// Selects the video.
        /// </summary>
        /// <returns>Select Video Task.</returns>
        private async Task SelectVideo()
        {
            Setup();

            //TODO Localize
            VideoInfo = "Selecting video";

            try
            {
                var mediaFile = await _mediaPicker.SelectVideoAsync(new VideoMediaStorageOptions());

                //TODO Localize
                VideoInfo = mediaFile != null
                                ? string.Format("Your video size {0} MB", ConvertBytesToMegabytes(mediaFile.Source.Length))
                                : "No video was selected";
            }
            catch (System.Exception ex)
            {
                if (ex is TaskCanceledException)
                {
                    //TODO Localize
                    VideoInfo = "Selecting video canceled";
                }
                else
                {
                    VideoInfo = ex.Message;
                }
            }
        }
       //public void CommitCommand()
       // {
       // }

        private static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
       
    }
}
