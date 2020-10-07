using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.ViewModel;

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowViewModel viewmodel = new WindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewmodel;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.StartGetImage();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.StopGetImage();
        }
    }
}
