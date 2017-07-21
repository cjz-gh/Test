using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IsmouseLeave lsm = new IsmouseLeave();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            this.b1.Visibility= Visibility.Visible;
        }

        private void Inforxaml_Hidden(object sender, EventArgs e)
        {
            this.b1.Visibility = Visibility.Hidden;
        }
        class IsmouseLeave
        {
            public event PropertyChangedEventHandler propertyChanged;
            private bool isMouseLeave;

            public bool IsMouseLeave {
                get { return isMouseLeave; }
                set
                {
                    isMouseLeave = value;
                    if (this.propertyChanged != null)
                    {
                        this.propertyChanged.Invoke(this, new PropertyChangedEventArgs("IsMouseLeave"));
                    }
                }
            }
        }
    }
}
