
using ExifLib;
using Portable.Controller;
using Portable.Modal;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Media;
using IMediaPicker = Xamarin.Forms.Labs.Services.Media.IMediaPicker;

namespace Portable.ViewModal
{
    [ViewType(typeof(CameraPage))]
    public class CameraViewModel : Xamarin.Forms.Labs.Mvvm.ViewModel
    {

        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();


        private IMediaPicker _mediaPicker;


        private ImageSource _imageSource;


        private string _videoInfo;


        private Command _takePictureCommand;


        private Command _selectPictureCommand;


        private Command _selectVideoCommand;
        private Command _savadetailcommand;

        private string _status;
        private int _id;
        private string _pagename;
        private byte[] _imgstream { get; set; }
        ////private CancellationTokenSource cancelSource;


        public CameraViewModel(int id, string pagename)
        {
            Setup();

            _id = id;
            _pagename = pagename;
        }


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


        public Command TakePictureCommand
        {
            get
            {
                return _takePictureCommand ?? (_takePictureCommand = new Command(
                                                                       async () => await TakePicture(),
                                                                       () => true));
            }
        }


        public Command SelectVideoCommand
        {
            get
            {
                return _selectVideoCommand ?? (_selectVideoCommand = new Command(
                                                                       async () => await SelectVideo(),
                                                                       () => true));
            }
        }


        public Command SelectPictureCommand
        {
            get
            {
                return _selectPictureCommand ?? (_selectPictureCommand = new Command(
                                                                           async () => await SelectPicture(),
                                                                           () => true));
            }
        }

        public Command SaveDetailCommand
        {
            get
            {
                return _savadetailcommand ?? (_savadetailcommand = new Command(
                                                                           async () => await SaveDetail(),
                                                                           () => true));
            }
        }

        public string Status
        {
            get { return _status; }
            private set { SetProperty(ref _status, value); }
        }


        private void Setup()
        {
            if (_mediaPicker != null)
            {
                return;
            }

            var device = Resolver.Resolve<IDevice>();

            ////RM: hack for working on windows phone? 
            _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
        }


        private async Task<MediaFile> TakePicture()
        {
            Setup();

            ImageSource = null;
            _imgstream = null;
            return await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400, SaveMediaOnCapture = true, Directory = "Images", Name = Guid.NewGuid().ToString() }).ContinueWith(t =>
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
                      MemoryStream ms = new MemoryStream();
                      mediaFile.Source.CopyTo(ms);
                      _imgstream = ms.ToArray();

                      ImageSource = ImageSource.FromStream(() => mediaFile.Source);
                      return mediaFile;
                  }

                  return null;
              }, _scheduler);
        }


        private async Task SelectPicture()
        {
            Setup();
            ImageSource = null;
            _imgstream = null;
            try
            {
                var mediaFile = await _mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Rear,
                    MaxPixelDimension = 400,
                    SaveMediaOnCapture = true
                });
                MemoryStream ms = new MemoryStream();
                mediaFile.Source.CopyTo(ms);
                _imgstream = ms.ToArray();

                ImageSource = ImageSource.FromStream(() => mediaFile.Source);
            }
            catch (System.Exception ex)
            {
                Status = ex.Message;
            }
        }


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

        public static byte[] streamToByteArray(Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

        private async Task SaveDetail()
        {
            //data save
            LocationPhoto lp = new LocationPhoto();
            lp.createon = DateTime.Now;
            lp.issupload = false;
            lp.isedit = false;

            //byte[] imageBytes = streamToByteArray(_imgstream);
            //StreamReader sr = new StreamReader(_imgstream);


            string str = "";
            str = Convert.ToBase64String(_imgstream);

            lp.Photo = str;
            //await App.Current.MainPage.DisplayAlert("Upload Image", str, "Yes", "No");
            //lp.Photo = System.Convert.FromBase64String(_imageSource);
            lp.PhotoDescription = _pagename;
            lp.PhotoUploadedDate = DateTime.Now;
            lp.LocationID = 0;
            lp.BuildingID = 0;
            lp.BuildingDeficiencyRepairID = 0;
            lp.buildingWorkOrderID = 0;
            lp.WorkOrderFollowUpID = 0;
            if (_pagename == "Location")
            {
                lp.LocationID = _id;
            }
            else if (_pagename == "FCA")
            {
                lp.BuildingID = _id;
            }
            else if (_pagename == "BuildingDeficiencyRepair")
            {
                lp.BuildingDeficiencyRepairID = _id;
            }
            else if (_pagename == "Facility")
            {
                lp.FacilityID = _id;
            }
            else if (_pagename == "WorkOrder")
            {
                lp.WorkOrderRequestID = _id;
            }
            else if (_pagename == "WorkOrderFollowUp")
            {
                lp.WorkOrderFollowUpID = _id;
            }
            else if (_pagename == "ProjectScreenBefore")
            {
                lp.ProjectBeforeID = _id;
            }
            else if (_pagename == "BuildingDeficiencyRepairScreen")
            {
                lp.DeficiencyRepairID = _id;
            }
            //else if (_pagename == "WorkOrderFollowUp")
            //{
            //    lp.WorkOrderFollowUpID = _id;
            //}
            //else if (_pagename == "WorkOrderFollowUp")
            //{
            //    lp.WorkOrderFollowUpID = _id;
            //}

            tblLocationPhoto dblp = new tblLocationPhoto();
            dblp.Add(lp);
            bool ans = await App.Current.MainPage.DisplayAlert("Upload Image", "Would you like to Upload another Image?", "Yes", "No");
            if (ans == true)
            {
                App.Current.MainPage = new MainPageCS(new CameraPage(_id, _pagename));
            }
            else if (ans == false)
            {
                //App.Current.MainPage = new MainPageCS(new LocationView());
                //redirection
                if (_pagename == "Location")
                {
                    Location loc = new Location();
                    tblLocation dbloc = new tblLocation();
                    loc = dbloc.Get(_id);
                    //await App.Current.MainPage.DisplayAlert("Selected Location", _id.ToString(), "Submit");
                    //tblJobType dbjobtype = new tblJobType();
                    //JobType jt = new JobType();
                    //jt = dbjobtype.Get(loc.JobTypeID);
                    if (loc.JobTypeID == 1)
                    {
                        if (loc.JobStatusID == 1)
                        {
                            App.Current.MainPage = new MainPageCS(new ProjectScreenBefore(_id, false));
                        }
                        else if (loc.JobStatusID == 2)
                        {
                            //App.Current.MainPage = new MainPageCS(new ProjectScreenActive(_id));
                        }
                        else if (loc.JobStatusID == 3)
                        {
                            //App.Current.MainPage = new MainPageCS(new ProjectScreenAfter(_id));
                        }
                    }
                    else if (loc.JobTypeID == 3)
                    {
                        App.Current.MainPage = new MainPageCS(new FCASystem(_id));
                    }
                    else if (loc.JobTypeID == 4)
                    {
                        App.Current.MainPage = new MainPageCS(new FacilityScreen(_id));
                    }
                    else
                    {
                        App.Current.MainPage = new MainPageCS(new LocationView());
                    }
                }
                else if (_pagename == "FCA")
                {
                    Building build = new Building();
                    tblBuilding DBbuild = new tblBuilding();
                    build = DBbuild.Get(_id);
                    if (build.IsDeficiencyRepair == true)
                    {
                        App.Current.MainPage = new MainPageCS(new FCADeficiencyScreen(_id));
                    }
                    else
                    {
                        App.Current.MainPage = new MainPageCS(new LocationView());
                    }
                }
                else if (_pagename == "BuildingDeficiencyRepair")
                {
                    App.Current.MainPage = new MainPageCS(new LocationView());
                }
                else if (_pagename == "Facility")
                {
                    tblBuilding DBBuild = new tblBuilding();
                    Building build = new Building();
                    build = DBBuild.Get(_id);
                    if (build.WorkOrder != "")
                    {
                        App.Current.MainPage = new MainPageCS(new WorkOrderRequest(_id));
                    }
                    else
                    {
                        App.Current.MainPage = new MainPageCS(new LocationView());
                    }

                }
                else if (_pagename == "WorkOrder")
                {
                    App.Current.MainPage = new MainPageCS(new WorkOrderFollowUpScreen(_id));
                }
                else if (_pagename == "ProjectScreenBefore")
                {
                    Building build = new Building();
                    tblBuilding DBbuild = new tblBuilding();
                    build = DBbuild.Get(_id);
                    bool isDetail = await App.Current.MainPage.DisplayAlert("Detail's", "Do you want add more detail ?", "Yes", "No");
                    if (build.IsDeficiencyRepair == true)
                    {
                        App.Current.MainPage = new MainPageCS(new ProposalChecklistFlatRoof(_id));
                    }
                    else
                    {
                        App.Current.MainPage = new MainPageCS(new DeficiencyRepairScreen(_id));
                    }

                }
                else if (_pagename == "ProjectScreenBefore")
                {

                }
                else
                {
                    App.Current.MainPage = new MainPageCS(new LocationView());
                }
            }
        }

        private static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
