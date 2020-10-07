using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using OpenCvSharp;

namespace WpfApp4.ViewModel
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        private BitmapSource _Img;
        public BitmapSource Img
        {
            get { return _Img; }
            set
            {
                _Img = value;
                OnPropertyChanged("Img");
            }
        }

        private CameraConnect Connecter = new CameraConnect();


        public WindowViewModel()
        {
            Connecter.CameraEvent += Connecter_CameraEvent;
        }

        private void Connecter_CameraEvent(BitmapSource displaySource)
        {
            Img = displaySource;
        }

        public void StartGetImage()
        {
            Connecter.StartCapture();
        }

        public void StopGetImage()
        {
            Connecter.StopCapture();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
