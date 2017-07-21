using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DictionaryTest
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
            string aa = "s4s,e#gg%j&fs*i(b\b)f/f-h+y0.5y[i]vh{hj}kkG";
            //tr = new Translation();
            //Binding binding = new Binding();
            //binding.Source = tr;
            //binding.Path = new PropertyPath("Dst");
            //BindingOperations.SetBinding(this.resultShow, Label.ContentProperty, binding);
        }
        private void SetBinding()
        {
            ObjectDataProvider odp = new ObjectDataProvider();
            odp.ObjectInstance = new BaiduApi();
            odp.MethodName = "GetTranslationFromBaiduFanyi";
            odp.MethodParameters.Add("");

            Binding inputBinding = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };
            Binding resultBinding = new Binding("Trans_result/Dst") { Source = odp};
            this.searchTextBox.SetBinding(TextBox.TextProperty, inputBinding);
            this.resultShow.SetBinding(Label.ContentProperty, resultBinding);
        }
        public string ReplaceStr(string str)
        {
            str = Regex.Replace(str, "[\\/ \\{ \\} \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]", " ");
            str = Regex.Replace(str, "[0-9]", " ");
            return str;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            IList<Dictionary> diclist = ModelConvertHelper<Dictionary>.ConvertToModel(AccessData.GetData());
            listView.ItemsSource = AccessData.GetData().DefaultView ;
        }
    }
}
