using System;
using System.IO;
using System.Text;

namespace PictureSlideShowGadget.Models
{
    public class SettingManager
    {
        public AppSettings Settings { get; set; }

        public SettingManager(string settingFilePath = "setting.txt")
        {
            if (string.IsNullOrEmpty(settingFilePath))
            {
                throw new ArgumentNullException("settingFilePath");
            }

            Settings = new AppSettings();
            using (StreamReader sr = new StreamReader(settingFilePath, Encoding.GetEncoding("Shift-JIS")))
            {
                Settings.DirectoryPath = sr.ReadLine();
                Settings.IntervalSeconds = int.Parse(sr.ReadLine());
            }
        }
    }
}
