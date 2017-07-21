using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DataTemplateTest1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialCarList();
        }
        private void InitialCarList()
        {
            List<Car> carlist = new List<Car>()
            {
                new Car(){AutoMarker="aa",Name="ad",Year="1900",TopSpeed="345"},
                new Car(){AutoMarker="aa",Name="bmw",Year="1920",TopSpeed="3s45"},
                new Car(){AutoMarker="aa",Name="bc",Year="1950",TopSpeed="34d5"},
                new Car(){AutoMarker="aa",Name="dz",Year="19300",TopSpeed="34f5"},
            };
            this.listBoxCars.ItemsSource = carlist;
        }
    }
    public class NameToPhotoPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = string.Format(@"/Resources/Images/{0}.jpg", (string)value);
            return new BitmapImage(new Uri(uriStr, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
