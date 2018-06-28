using AulePiu.CorsoOvernet.Messages;
using AulePiu.CorsoOvernet.ViewModels;
using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Shapes;
using WPFLocalizeExtension.Engine;

namespace AulePiu.CorsoOvernet.WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            // Qui sono in WPF...
            var vm = this.Resources["viewmodel"] as LoginViewModel;
            vm.LanguageChanged += (s, e) => {
                LocalizeDictionary.Instance.Culture =
                new System.Globalization.CultureInfo(e);
            };
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            // Messenger.Default.Send<CloseViewMessage>(new CloseViewMessage());

            this.Close();
        }

        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    var vm = this.Resources["viewmodel"] as LoginViewModel;
        //    vm.CheckAuth();
        //}
    }
}
