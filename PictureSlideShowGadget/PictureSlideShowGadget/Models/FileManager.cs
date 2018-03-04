using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _filePathList.AddRange(System.IO.Directory.GetFiles(dirPath, "*." + ext, System.IO.SearchOption.AllDirectories));
            }
        }

        public string GetImageFilePath()
        {
            string output = _filePathList[_currentImageIndex++];
            _currentImageIndex %= _filePathList.Count;
            return output;
        }
    }
}
