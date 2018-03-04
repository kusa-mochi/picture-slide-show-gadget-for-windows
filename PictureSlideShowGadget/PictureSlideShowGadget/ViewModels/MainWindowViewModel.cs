using Prism.Mvvm;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

using PictureSlideShowGadget.Models;

namespace PictureSlideShowGadget.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private FileManager _fileManager = null;
        private string _title = "Picture Slide Show Gadget for Windows";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            _fileManager = new FileManager(@"C:\Users\R\Desktop\新しいフォルダー");
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(UpdateImage);
            timer.Start();
        }

        private void UpdateImage(object sender, EventArgs e)
        {
            ImageData = new BitmapImage(new System.Uri(_fileManager.GetImageFilePath()));
        }

        private BitmapImage _ImageData;
        public BitmapImage ImageData
        {
            get { return _ImageData; }
            set { SetProperty(ref _ImageData, value); }
        }
    }
}
