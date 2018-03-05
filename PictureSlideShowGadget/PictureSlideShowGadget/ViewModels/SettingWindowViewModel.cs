using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PictureSlideShowGadget.ViewModels
{
    public class SettingWindowViewModel : BindableBase
    {
        public SettingWindowViewModel()
        {

        }

        private string _DirectoryPath;
        public string DirectoryPath
        {
            get { return _DirectoryPath; }
            set { SetProperty(ref _DirectoryPath, value); }
        }

        private bool _Recursive;
        public bool Recursive
        {
            get { return _Recursive; }
            set { SetProperty(ref _Recursive, value); }
        }

        private int _Interval;
        public int Interval
        {
            get { return _Interval; }
            set { SetProperty(ref _Interval, value); }
        }
    }
}
