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
using System.Windows.Shapes;

namespace PasGen
{
    /// <summary>
    /// Interaction logic for WindowSettings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        public WindowSettings()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            btn1.Background = Brushes.LightBlue;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            btn2.Background = Brushes.Pink;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            btn1.Background = Brushes.Pink;
            btn2.Background = Brushes.LightBlue;
        }
    }
}
