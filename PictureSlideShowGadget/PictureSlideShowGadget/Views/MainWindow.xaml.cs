using System.Windows;
using System.Windows.Input;

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

            this.Left = Properties.Settings.Default.WindowPositionX;
            this.Top = Properties.Settings.Default.WindowPositionY;
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
                Properties.Settings.Default.Save();
            }
        }
    }
}
