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

namespace CommandTest1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initializeCommand();
        }

        private RoutedCommand clearCmd = new RoutedCommand();

        private void initializeCommand()
        {
            //把命令赋值给命令源
            this.button.Command = clearCmd;
            //指定快捷键
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //指定命令目标
            this.button.CommandTarget = this.textbox;

            //创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = clearCmd;
            cb.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(cb_Excute);
            stackPanel.CommandBindings.Add(cb);
        }
        void cb_CanExecute(object sender,CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            e.Handled = true;
        }
        void cb_Excute(object sender, ExecutedRoutedEventArgs e)
        {
            this.textbox.Clear();
            e.Handled = true;
        }
    }
}
