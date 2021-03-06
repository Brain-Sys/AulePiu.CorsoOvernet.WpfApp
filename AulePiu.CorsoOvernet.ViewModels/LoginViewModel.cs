﻿using AulePiu.CorsoOvernet.Authentication;
using AulePiu.CorsoOvernet.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace AulePiu.CorsoOvernet.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Timer timer;

        public List<string> Languages { get; set; }

        private string selectedLanguage;
        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set { selectedLanguage = value;
                base.RaisePropertyChanged();

                // Scateno l'evento di "lingua cambiata"
                this.LanguageChanged?.Invoke(this, this.SelectedLanguage);
            }
        }

        public event EventHandler<string> LanguageChanged;

        // PascalCase
        // public string Username { get; set; }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                base.RaisePropertyChanged();
                this.LoginCommand.RaiseCanExecuteChanged();

                // Scatena PropertyChanged solo quando
                // il valore cambia
                // base.Set(nameof(Username), ref username, value);
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                base.RaisePropertyChanged();
                this.LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public bool SaveCredentials { get; set; }

        // Fields (NO), mettere get & set per fare una property
        private DateTime currentTime;
        public DateTime CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                base.RaisePropertyChanged();
            }
        }

        private bool? ok;
        public bool? Ok
        {
            get { return ok; }
            set
            {
                ok = value;
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

            this.Languages = new List<string>() { "en-US", "it-IT" };

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

            if (this.Ok == true)
            {
                var msg = new OpenNewViewMessage();
                msg.ViewName = "MainMenu";
                msg.Modal = false;
                Messenger.Default.Send<OpenNewViewMessage>(msg);
            }
            else
            {
                var msg = new QuestionMessage
                    ("Errore!", "Login fallito! Vuoi ritentare?");
                msg.Yes = () => {
                    this.Ok = null;
                    this.Password = string.Empty;
                };
                msg.No = () => {
                    Messenger.Default.Send<CloseApplicationMessage>(
                        CloseApplicationMessage.Empty);
                };

                Messenger.Default.Send<QuestionMessage>(msg);
            }
        }

        //public void close()
        //{
        //    var closeMsg = new CloseViewMessage();
        //    closeMsg.ViewName = "Login";
        //    Messenger.Default.Send<CloseViewMessage>(closeMsg);
        //}

        private void updateTimer(object state)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            this.CurrentTime = DateTime.Now;
        }
    }
}