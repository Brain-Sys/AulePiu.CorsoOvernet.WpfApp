using AulePiu.CorsoOvernet.Messages;
using GalaSoft.MvvmLight.Messaging;
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
            this.ShutdownMode = ShutdownMode.OnLastWindowClose;

            Messenger.Default.Register<OpenNewViewMessage>(this, openNewView);
            Messenger.Default.Register<ShowMessage>(this, showMessage);
            Messenger.Default.Register<QuestionMessage>(this, askQuestion);
            Messenger.Default.Register<CloseApplicationMessage>(this, closeApp);
            Messenger.Default.Register<CloseViewMessage>(this, closeView);
        }

        private void closeView(CloseViewMessage obj)
        {
            foreach (Window wnd in Application.Current.Windows)
            {
                if (wnd.GetType().Name.StartsWith(obj.ViewName))
                {
                    wnd.Close();
                }
            }
        }

        private void closeApp(CloseApplicationMessage obj)
        {
            Application.Current.Shutdown(obj.ExitCode);
        }

        private void askQuestion(QuestionMessage obj)
        {
            var result = MessageBox.Show(obj.Text, obj.Title,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                obj.Yes?.Invoke();
            }
            else
            {
                obj.No?.Invoke();
            }
        }

        private void showMessage(ShowMessage obj)
        {
            MessageBox.Show(obj.Text, obj.Title,
                MessageBoxButton.OK,
                MessageBoxImage.Exclamation);
        }

        private void openNewView(OpenNewViewMessage obj)
        {
            Window wnd = null;

            Type type = Type.GetType(string.Format("AulePiu.CorsoOvernet.WpfApp.{0}Window, AulePiu.CorsoOvernet.WpfApp", obj.ViewName));

            if (type != null)
            {
                wnd = Activator.CreateInstance(type) as Window;

                if (wnd != null)
                {
                    if (obj.Modal)
                    {
                        wnd.ShowDialog();
                    }
                    else
                    {
                        wnd.Show();
                    }
                }
            }
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
