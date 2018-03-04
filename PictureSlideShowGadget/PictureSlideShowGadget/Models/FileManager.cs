using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

using ExifLib;

namespace PictureSlideShowGadget.Models
{
    public class FileManager
    {
        private List<string> _filePathList = null;
        private int _currentImageIndex = 0;

        public FileManager(string dirPath, string[] extList = null)
        {
            if (string.IsNullOrEmpty(dirPath))
            {
                throw new ArgumentNullException("dirPath");
            }

            if (extList == null)
            {
                extList = new string[] { "jpg", "png", "bmp", "gif", "tiff" };
            }

            _filePathList = new List<string>();

            foreach (string ext in extList)
            {
                _filePathList.AddRange(Directory.GetFiles(dirPath, "*." + ext, SearchOption.AllDirectories));
            }
        }

        public BitmapImage GetImageFile()
        {
            string filePath = _filePathList[_currentImageIndex++];
            _currentImageIndex %= _filePathList.Count;

            BitmapImage output = new BitmapImage();

            using (ExifReader exifReader = new ExifReader(filePath))
            {
                ExifTags orientation;
                exifReader.GetTagValue<ExifTags>(ExifTags.Orientation, out orientation);
                output.BeginInit();
                output.UriSource = new Uri(filePath);
                switch(orientation)
                {
                    case ExifTags.GPSLatitudeRef:
                        // no rotate
                        break;
                    case ExifTags.GPSAltitude:
                        // rotate the image -90 deg.
                        output.Rotation = Rotation.Rotate90;
                        break;
                    case ExifTags.GPSLongitudeRef:
                        // rotate the image -180 deg.
                        output.Rotation = Rotation.Rotate180;
                        break;
                }
                output.EndInit();
            }

            return output;
        }
    }
}
