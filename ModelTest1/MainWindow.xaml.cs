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
                new Car(){AutoMark="aa",Name="ad",Year="1900",TopSpeed="345"},
                new Car(){AutoMark="aa",Name="bmw",Year="1920",TopSpeed="3s45"},
                new Car(){AutoMark="aa",Name="bc",Year="1950",TopSpeed="34d5"},
                new Car(){AutoMark="aa",Name="dz",Year="19300",TopSpeed="34f5"},
            };
            foreach(Car car in carlist)
            {
                CarlistItem view = new CarlistItem();
                view.Car = car;
                this.listbox.Items.Add(view);
            }
        }
        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarlistItem view = e.AddedItems[0] as CarlistItem;
            if(view != null)
            {
                this.carview.Car = view.Car;
            }
        }
    }
}
