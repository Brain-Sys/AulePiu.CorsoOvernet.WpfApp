using AulePiu.CorsoOvernet.Authentication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Threading;

namespace AulePiu.CorsoOvernet.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Timer timer;

        // PascalCase
        // public string Username { get; set; }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value;
                base.RaisePropertyChanged();
                this.LoginCommand.RaiseCanExecuteChanged();

                // Scatena PropertyChanged solo quando
                // il valore cambia
                // base.Set(nameof(Username), ref username, value);
            }
        }

        public string Password { get; set; }
        public bool SaveCredentials { get; set; }

        // Fields (NO), mettere get & set per fare una property
        private DateTime currentTime;
        public DateTime CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value;
                base.RaisePropertyChanged();
            }
        }

        private bool? ok;
        public bool? Ok
        {
            get { return ok; }
            set { ok = value;
                base.RaisePropertyChanged();
            }
        }

        public RelayCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            this.LoginCommand = new RelayCommand
                (loginCommandExecute, loginCommandCanExecute);
            int id = Thread.CurrentThread.ManagedThreadId;
            this.Username = "bologna";
            this.Password = "pwd";
            this.CurrentTime = DateTime.Now;

            timer = new Timer(updateTimer, null, 0, 1000);
        }

        private bool loginCommandCanExecute()
        {
            if (string.IsNullOrEmpty(this.Username) ||
                string.IsNullOrEmpty(this.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void loginCommandExecute()
        {
            AuthEngine eng = new AuthEngine();
            this.Ok = eng.Check(this.Username, this.Password);
        }

        private void updateTimer(object state)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            this.CurrentTime = DateTime.Now;
        }
    }
}