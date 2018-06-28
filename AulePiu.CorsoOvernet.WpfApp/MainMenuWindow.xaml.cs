using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AulePiu.CorsoOvernet.WpfApp
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = Thread.CurrentThread.ManagedThreadId;

            // ThreadPool.QueueUserWorkItem((o) => { });

            Task.Run(() => {
                id = Thread.CurrentThread.ManagedThreadId;
                this.Dispatcher.BeginInvoke(new Action(task));
            });

            //this.task();
        }

        private void task()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            this.WindowState = WindowState.Maximized;
            while(true) { }
        }
    }
}
