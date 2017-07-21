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
using System.ComponentModel;

namespace WpfUseBlinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Student> stuList = new List<Student>()
            {
                new Student(){Id=0,Name="a",Age=12},
                new  Student(){Id=1,Name="aa",Age=12},
                new Student(){Id=2,Name="aaa",Age=12},
            };
            this.listBoxStudents.ItemsSource = stuList;
            this.listBoxStudents.DisplayMemberPath = "Name";
            Binding binding = new Binding("SelectedItem.Name") { Source = this.listBoxStudents };
            this.textBoxId.SetBinding(TextBox.TextProperty, binding);
        }
    }
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
