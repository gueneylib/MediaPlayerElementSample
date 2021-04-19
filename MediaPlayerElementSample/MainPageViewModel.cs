using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LibVLCSharp.Shared;

namespace MediaPlayerElementSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CarouselModel> CarouselItems { get; set; }
        public MainPageViewModel()
        {
            Core.Initialize();

            CarouselItems = new ObservableCollection<CarouselModel>
            {
                new CarouselModel
                {
                    ModelType = "Normal",
                    Headline = "First Item Headline",
                    Subline = "First Item Subline"
                },
                new CarouselModel
                {
                    ModelType = "Normal",
                    Headline = "Second Item Headline",
                    Subline = "Second Item Subline"
                },
                new CarouselModel
                {
                    ModelType = "Normal",
                    Headline = "Third Item Headline",
                    Subline = "Third Item Subline"
                },
                CreateNewVideoItem(
                    "Video",
                    "Fourth Item Headline - First Video",
                    "Fourth Item Subline - First Video",
                    "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"),
                CreateNewVideoItem(
                    "Video",
                    "Fourth Item Headline - Second Video",
                    "Fourth Item Subline - Second Video",
                    "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"),
                new CarouselModel
                {
                    ModelType = "Normal",
                    Headline = "Sixth Item Headline",
                    Subline = "Sixth Item Subline"
                },
                new CarouselModel
                {
                    ModelType = "Normal",
                    Headline = "Seventh Item Headline",
                    Subline = "Seventh Item Subline"
                },
                new CarouselModel
                {
                    ModelType = "Normal",
                    Headline = "Eighth Item Headline",
                    Subline = "Eighth Item Subline"
                },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private CarouselModel CreateNewVideoItem(string modelType, string headline, string subline, string videoUrl)
        {
            var libVLC = new LibVLC();
            var media = new LibVLCSharp.Shared.Media(libVLC,
                new Uri(videoUrl));
            var mediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
            media.Dispose();
            mediaPlayer.Stop();

            return new CarouselModel
            {
                ModelType = modelType,
                Headline = headline,
                Subline = subline,
                MediaPlayer = mediaPlayer,
                LibVLC = libVLC
            };
        }
    }

    public class CarouselModel : INotifyPropertyChanged
    {
        string _modelType;
        public string ModelType
        {
            get { return _modelType; }
            set
            {
                _modelType = value;
                OnPropertyChanged("ModelType");
            }
        }

        string _headline;
        public string Headline
        {
            get { return _headline; }
            set
            {
                _headline = value;
                OnPropertyChanged("Headline");
            }
        }

        string _subline;
        public string Subline
        {
            get { return _subline; }
            set
            {
                _subline = value;
                OnPropertyChanged("Subline");
            }
        }

        string _videoUrl;
        public string VideoUrl
        {
            get { return _videoUrl; }
            set
            {
                _videoUrl = value;
                OnPropertyChanged("VideoUrl");
            }
        }

        MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get { return _mediaPlayer; }
            set
            {
                _mediaPlayer = value;
                OnPropertyChanged("MediaPlayer");
            }
        }

        LibVLC _libVLC;
        public LibVLC LibVLC
        {
            get { return _libVLC; }
            set
            {
                _libVLC = value;
                OnPropertyChanged("LibVLC");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
