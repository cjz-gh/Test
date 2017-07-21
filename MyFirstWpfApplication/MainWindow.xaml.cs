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

namespace MyFirstWpfApplication
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

    }
    class MyButton:Button
    {
        //声明和注册路由事件
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEnventsArgs>), typeof(MyButton));
        //CLR事件包装器
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }
        //激发路由事件
        protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEnventsArgs args = new ReportTimeEnventsArgs(ReportTimeEvent, this);
            args.ChickTime = DateTime.Now;
            this.RaiseEvent(args);
        }
        //public Type UserWindowType { get; set; }
        //protected override void OnClick()
        //{
        //    base.OnClick();
        //    Window win = Activator.CreateInstance(this.UserWindowType) as Window;
        //    if (win != null)
        //    {
        //        win.ShowDialog();
        //    }
        //}
    }
    class ReportTimeEnventsArgs : RoutedEventArgs
    {
        public ReportTimeEnventsArgs(RoutedEvent routedEvent, Object source) : base(routedEvent, source)
        {

        }
        public DateTime ChickTime { get; set; }
    }
}
