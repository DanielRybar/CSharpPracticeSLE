using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_09NavrhoveVzory2
{
    interface IImage
    {
        void Display();
    }

    class RealImage : IImage // skutecny obrazek, k tomu nemam pristup
    {
        private readonly string _filename;

        public RealImage(string filename)
        {
            _filename = filename;
            LoadImageFromDisk();
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image {_filename}");
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine($"Loading image {_filename} from disk...");
        }
    }

    class ImageProxy : IImage // mohu komunikovat pouze se zastupcem
    {
        private readonly string _filename;
        private RealImage _image;

        public ImageProxy(string filename)
        {
            _filename = filename;
        }

        public void Display()
        {
            if (_image == null)
            {
                _image = new RealImage(_filename);
            }
            _image.Display();
        }
    }
}