using Prism.Mvvm;
using System;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

using PictureSlideShowGadget.Views;
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

        private BitmapImage _ImageData;
        public BitmapImage ImageData
        {
            get { return _ImageData; }
            set { SetProperty(ref _ImageData, value); }
        }

        private bool _Exit = false;
        public bool Exit
        {
            get { return _Exit; }
            set { SetProperty(ref _Exit, value); }
        }

        public MainWindowViewModel()
        {
            _settingManager = new SettingManager();
            _fileManager = new FileManager(_settingManager.Settings.DirectoryPath);

            //// if there is no directory setting data,
            //if ((Properties.Settings.Default.DirectoryPath == "nodata") ||
            //    string.IsNullOrEmpty(Properties.Settings.Default.DirectoryPath) ||
            //    string.IsNullOrWhiteSpace(Properties.Settings.Default.DirectoryPath))
            //{
            //    // open Settings Dialog
            //    var dialog = new SettingWindow();
            //    dialog.ShowDialog();


            //    //var dialog = new FolderBrowserDialog();
            //    //dialog.Description = "Select a folder to load pictures.";

            //    //var result = dialog.ShowDialog();

            //    //if (result == DialogResult.OK)
            //    //{
            //    //    Properties.Settings.Default.DirectoryPath = dialog.SelectedPath;
            //    //}
            //    //else if(result == DialogResult.Cancel)
            //    //{
            //    //    Exit = true;
            //    //    return;
            //    //}
            //}

            //_fileManager = new FileManager(Properties.Settings.Default.DirectoryPath);

            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = new TimeSpan((long)Properties.Settings.Default.IntervalSec * 1000 * 1000 * 10);
            timer.Tick += new EventHandler(UpdateImage);
            ImageData = _fileManager.GetImageFile();
            timer.Start();
        }

        private void UpdateImage(object sender, EventArgs e)
        {
            ImageData = _fileManager.GetImageFile();
        }
    }
}
