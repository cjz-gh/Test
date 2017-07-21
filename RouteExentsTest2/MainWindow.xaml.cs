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

namespace RouteExentsTest2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected int eventConter = 0;
        private void SomeThingClicked(object sender, MouseButtonEventArgs e)
        {
            eventConter++;
            string message = "#" + eventConter.ToString() + ":\r\n" + "sender" + sender.ToString() + "\r\n" + "source" + e.Source + "\r\n" + "original source:" + e.OriginalSource;
            lstMessage.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessage.Items.Clear();
            eventConter = 0;
        }

        private void cmdClear_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (e.Key == Key.U)
                {
                    cmdClear_Click(sender, e);
                }
            }
                  
        }
    }
}
