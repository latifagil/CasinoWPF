using CasinoWPF.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using CasinoWPF.Pages;

namespace CasinoWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        MainWindow _mainWindow;
        public LoginPage(MainWindow mainindow)
        {
            InitializeComponent();

            _mainWindow = mainindow;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            var loginObj = ConnectionClass.casino.Login.FirstOrDefault(log => log.Email == login && log.Password == password);
            var userObj = ConnectionClass.casino.Users.FirstOrDefault(log => log.LoginID == loginObj.LoginID);
            //MessageBox.Show(userObj.FirstName);
            if (loginObj == null)
            {
                MessageBox.Show("No such player try again!");
                txtPassword.Password = "";
                txtLogin.Text = "";
                return;
            }

            //var a = (sender as Button).DataContext as DBModel.Users;
            _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(login, password));

        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
