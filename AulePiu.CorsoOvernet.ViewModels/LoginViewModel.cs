using System;
using System.ComponentModel;
using System.Threading;

namespace AulePiu.CorsoOvernet.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Timer timer;

        public event PropertyChangedEventHandler PropertyChanged;

        // PascalCase
        // public string Username { get; set; }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password { get; set; }
        public bool SaveCredentials { get; set; }

        // Fields (NO), mettere get & set per fare una property
        public DateTime CurrentTime { get; set; }

        public LoginViewModel()
        {
            this.Username = "igor";
            this.Password = "pwd";
            this.CurrentTime = DateTime.Now;

            timer = new Timer(updateTimer, null, 0, 1000);
        }

        private void updateTimer(object state)
        {
            this.CurrentTime = DateTime.Now;

            // C'è qualcuno sottoscritto a questo evento?
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs(nameof(CurrentTime)));
            }
        }

        public void CheckAuth()
        {

        }
    }
}