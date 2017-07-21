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

namespace ModelTest1
{
    /// <summary>
    /// CarlistItem.xaml 的交互逻辑
    /// </summary>
    public partial class CarlistItem : UserControl
    {
        public CarlistItem()
        {
            InitializeComponent();
        }
        private Car car;
        public Car Car
        {
            get { return car; }
            set
            {
                car = value;
                this.Name.Text = car.Name;
                string uriStr = string.Format(@"/Resources/Images/{0}.jpg", car.Name);
                this.imagePhoto.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }
    }
}
