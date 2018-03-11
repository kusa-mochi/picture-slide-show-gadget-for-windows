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

        private BitmapImage _FadeImage;
        public BitmapImage FadeImage
        {
            get { return _FadeImage; }
            set
            {
                SetProperty(ref _FadeImage, value);
            }
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

            ImageData = _fileManager.GetImageFile();
            _FadeImage = ImageData.Clone();
        }

        public void UpdateFadeImage()
        {
            FadeImage = _fileManager.GetImageFile();
        }

        public void UpdateImageData()
        {
            ImageData = FadeImage.Clone();
        }
    }
}
