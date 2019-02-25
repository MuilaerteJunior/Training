using GSAP_Reliable.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace GSAP_Reliable {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private int count = 1;

        public MainWindow() {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void BtnRSS_Click(object sender, RoutedEventArgs e) {
            //BusyIndicator.Visibility = Visibility.Visible;
            BtnRSS.IsEnabled = false;

            var client = new WebClient();
            client.DownloadStringAsync(new Uri("http://www.filipekberg.se/rss/"));
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
            //BusyIndicator.Visibility = Visibility.Hidden;
            BtnRSS.IsEnabled = true;

            TxtRSS.Text = e.Result;
        }

        private void BtnCounter_Click(object sender, RoutedEventArgs e) {
            TxtCounter.Text = "Counter: "  + count++;
        }
    }
}