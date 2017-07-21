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

namespace RouteToReportTimeTest
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

        private void ReportTimeHandler(object sender, ReportTimeEnventsArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ChickTime.ToLongTimeString();
            string content = string.Format("{0}到达{1}", timeStr, element.Name);
            this.listBox.Items.Add(content);
        }

        private void g1_ReportTime(object sender, ReportTimeEnventsArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ChickTime.ToLongTimeString();
            string content = string.Format("{0}到达{1}", timeStr, element.Name);
            this.listBox.Items.Add(content);
            if (element == g2)
            {
                e.Handled = true;
            }
        }
    }
    class ReportTimeEnventsArgs : RoutedEventArgs
    {
        public ReportTimeEnventsArgs(RoutedEvent routedEvent, Object source) : base(routedEvent, source)
        {

        }
        public DateTime ChickTime { get; set; }
    }
    public class TimeButton : Button
    {
        //声明和注册路由事件
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEnventsArgs>), typeof(TimeButton));
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
    }
}
