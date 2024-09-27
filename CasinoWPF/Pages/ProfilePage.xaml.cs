using CasinoWPF.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CasinoWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        
        public ProfilePage(string login, string password)
        {
            InitializeComponent();
            loginObj = ConnectionClass.casino.Login.FirstOrDefault(log => log.Email == login && log.Password == password);
            userObj = ConnectionClass.casino.Users.FirstOrDefault(log => log.LoginID == loginObj.LoginID);

            FirstNameBox.Text = userObj.FirstName;
            LastNameBox.Text = userObj.LastName;
            UsernameBox.Text = userObj.Username;
            DateBox.Text = Convert.ToString(userObj.RegistrationDate);




        }


        Users userObj;
        Login loginObj;

        private void EditBtn_Click(object sender, object e)
        {

            NavigationService.Navigate(new EditPage(userObj, loginObj));

        }

        private void AddMoneyBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TransactionPage(loginObj.Email, loginObj.Password));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(userObj.Balance));
        }

        private void GameBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Game(loginObj.Email, loginObj.Password));
        }
    }
}
