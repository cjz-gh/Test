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

namespace BindingRelativeSourceTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //自身数据
            RelativeSource rs = new RelativeSource(RelativeSourceMode.Self);
            //其他数据
            //RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            //rs.AncestorLevel = 2;
            //rs.AncestorType = typeof(Grid);
            Binding binding = new Binding("Name")
            {
                RelativeSource = rs,
            };
            this.t1.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
