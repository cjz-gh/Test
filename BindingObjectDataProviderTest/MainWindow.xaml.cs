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

namespace BindingObjectDataProviderTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetBinding();
        }
        public void SetBinding()
        {
            ObjectDataProvider odp = new ObjectDataProvider();
            odp.ObjectInstance = new CalCulator();
            odp.MethodName = "Add";
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");
            Binding bindingToArg1 = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged,
            };
            Binding bindingToArg2 = new Binding("MethodParameters[1]") {
                Source=odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };
            Binding bindingToResult = new Binding(".") { Source = odp };
            this.textBoxArg1.SetBinding(TextBox.TextProperty, bindingToArg1);
            this.textBoxArg2.SetBinding(TextBox.TextProperty, bindingToArg2);
            this.textBoxArg3.SetBinding(TextBox.TextProperty, bindingToResult);
        }
    }
    class CalCulator
    {
        public string Add (string arg1,string arg2)
        {
            double x=0;
            double y=0;
            double z=0;
            if(double.TryParse(arg1,out x)&&double.TryParse(arg2,out y)){
                z = x + y;
                return z.ToString();
            }
            return ("input error");
        }
    }
}
