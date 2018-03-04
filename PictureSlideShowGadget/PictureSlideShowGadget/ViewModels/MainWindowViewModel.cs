using Prism.Mvvm;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

using PictureSlideShowGadget.Models;

namespace PictureSlideShowGadget.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private SettingManager _settingManager = null;
        private FileManager _fileManager = null;
        private string _title = "Picture Slide Show Gadget for Windows";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            _settingManager = new SettingManager();
            _fileManager = new FileManager(_settingManager.Settings.DirectoryPath);
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = new TimeSpan((long)_settingManager.Settings.IntervalSeconds * 1000 * 1000 * 10);
            timer.Tick += new EventHandler(UpdateImage);
            ImageData = _fileManager.GetImageFile();
            timer.Start();
        }

        private void UpdateImage(object sender, EventArgs e)
        {
            ImageData = _fileManager.GetImageFile();
        }

        private BitmapImage _ImageData;
        public BitmapImage ImageData
        {
            get { return _ImageData; }
            set { SetProperty(ref _ImageData, value); }
        }
    }
}
