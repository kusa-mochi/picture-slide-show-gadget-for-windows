using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

using PictureSlideShowGadget.ViewModels;

namespace PictureSlideShowGadget.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();

            this.Left = Properties.Settings.Default.WindowPositionX;
            this.Top = Properties.Settings.Default.WindowPositionY;
            this.Width = Properties.Settings.Default.WindowWidth;
            this.Height = Properties.Settings.Default.WindowHeight;

            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = new TimeSpan((long)Properties.Settings.Default.IntervalSec * 1000 * 1000 * 10);
            timer.Tick += new EventHandler(UpdateFadeImage);
            timer.Start();
        }

        private void UpdateFadeImage(object sender, EventArgs e)
        {
            ((MainWindowViewModel)(this.DataContext)).UpdateFadeImage();

            Storyboard fadeStoryboard = this.Resources["ImageFadeAnimation"] as Storyboard;
            fadeStoryboard.Completed += UpdateImageData;
            fadeStoryboard.Begin();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState != MouseButtonState.Pressed) return;

            this.DragMove();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                Properties.Settings.Default.WindowPositionX = this.Left;
                Properties.Settings.Default.WindowPositionY = this.Top;
                Properties.Settings.Default.WindowWidth = this.Width;
                Properties.Settings.Default.WindowHeight = this.Height;
                Properties.Settings.Default.Save();
            }
        }

        private void UpdateImageData(object sender, EventArgs e)
        {
            ((MainWindowViewModel)this.DataContext).UpdateImageData();
            this.FadeLayer.Opacity = 0.0;
        }
    }
}
