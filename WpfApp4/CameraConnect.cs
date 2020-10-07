using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Media.Imaging;
using OpenCvSharp;

namespace WpfApp4
{
    class CameraConnect
    {
        public delegate void dlg_Camera(BitmapSource displaySource);
        public event dlg_Camera CameraEvent;

        private VideoCapture CameraCoordinator = new VideoCapture();
        private Thread CameraThread;

        //private ManualResetEvent resetEvent = new ManualResetEvent(true);
        private bool isRunning = false;
        public void StartCapture()
        {
            StopThread();
            StartThread();
        }

        public void StopCapture()
        {
            StopThread();
        }

        private void StartThread()
        {
            isRunning = true;
            try
            {
                CameraThread = new Thread(Run);
                CameraThread.IsBackground = true;
                CameraThread.Start();
            }
            catch { }
        }

        private void StopThread()
        {
            isRunning = false;

            if (CameraThread != null && CameraThread.IsAlive)
            {
                try
                {
                    CameraCoordinator.Release();
                    CameraThread.Abort();
                }
                catch { }
                finally
                {
                    CameraThread = null;
                }
            }

        }

        private void Run()
        {
            CameraCoordinator.Open(0);
            while (isRunning)
            {
                if (!CameraCoordinator.IsOpened())
                {
                    break;
                }

                //Mat img = new Mat(@"D:\ProjectData\MonitorMysticLight\Gaming\MAG271VCR\MAG271VCR_device.png");  
                Mat img = new Mat();
                if (CameraCoordinator.Read(img))
                {
                    var img_dispaly = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(img);
                    img_dispaly.Freeze();
                    CameraEvent?.Invoke(img_dispaly);
                    //Thread.Sleep(1000);
                }
            }
            CameraCoordinator.Release();
        }
    }
}
