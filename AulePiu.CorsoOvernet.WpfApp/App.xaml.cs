using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AulePiu.CorsoOvernet.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var ex = e.Exception;
            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            string[] arguments = e.Args;
            base.OnStartup(e);

            var wnd = new LoginWindow();
            wnd.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            e.ApplicationExitCode = 0;
        }
    }
}
