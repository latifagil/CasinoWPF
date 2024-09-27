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

namespace CasinoWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        DBModel.Users _users;
        DBModel.Login _login;
        public EditPage(DBModel.Users users, DBModel.Login login)
        {
            InitializeComponent();
            _users = users;
            _login = login;

            name.Text = users.FirstName;
            lastname.Text = users.LastName;
            username.Text = users.Username;
            password.Text = login.Password;
            email.Text = login.Email;
        }
       
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var a = ConnectionClass.casino.Users.Where(z => z.UserID ==  _users.UserID).FirstOrDefault();
            var b = ConnectionClass.casino.Login.Where(z => z.LoginID == _login.LoginID).FirstOrDefault();
            a.FirstName = name.Text;
            a.LastName = lastname.Text;
            a.Username = username.Text;
            b.Email = email.Text;
            b.Password = password.Text;
            ConnectionClass.casino.SaveChanges();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(_login.Email, _login.Password));
        }
    }
}
