using CasinoWPF.DBModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;
using CasinoWPF.Pages;

namespace CasinoWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        Users _users = new Users();
        Login _login = new Login();

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненность полей
            if (string.IsNullOrEmpty(name.Text) ||
                string.IsNullOrEmpty(lastname.Text) ||
                string.IsNullOrEmpty(username.Text) || 
                string.IsNullOrEmpty(email.Text) || 
                string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("All fiels must be filled!!");
                return;
            }






            _users.FirstName = name.Text;
            _users.LastName = lastname.Text;
            _users.Username = username.Text;
            _login.Email = email.Text;
            _login.Password = password.Text;
            _users.LoginID = _login.LoginID;
            _users.RegistrationDate = DateTime.Now;
            _users.Balance = 3000;



            ConnectionClass.casino.Users.Add(_users);
            ConnectionClass.casino.Login.Add(_login);
            ConnectionClass.casino.SaveChanges();

            NavigationService.GoBack();
        }
    }
}
