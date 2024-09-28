using CasinoWPF.DBModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CasinoWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для TransactionPage.xaml
    /// </summary>
    public partial class TransactionPage : Page
    {
        public TransactionPage(string login, string password)
        {
            InitializeComponent();
            loginObj = ConnectionClass.casino.Login.FirstOrDefault(log => log.Email == login && log.Password == password);
            userObj = ConnectionClass.casino.Users.FirstOrDefault(log => log.LoginID == loginObj.LoginID);

            balanceBox.Text = Convert.ToString(userObj.Balance);
          
        }
        Login loginObj;
        Users userObj;

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            if (Convert.ToDecimal(addbalance.Text) < 0)
            {
                MessageBox.Show("Value must be positive");
                return;
            }

            userObj.Balance += Convert.ToDecimal(addbalance.Text);
            balanceBox.Text =Convert.ToString(Convert.ToDecimal(balanceBox.Text) + Convert.ToDecimal(addbalance.Text));

            ConnectionClass.casino.SaveChanges();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void GetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDecimal(addbalance.Text) < 0 || Convert.ToDecimal(addbalance.Text) > userObj.Balance)
            {
                MessageBox.Show("Value must be positive and less or equal than your balance");
                return;
            }

            userObj.Balance -= Convert.ToDecimal(addbalance.Text);
            balanceBox.Text = Convert.ToString(Convert.ToDecimal(balanceBox.Text) - Convert.ToDecimal(addbalance.Text));

            ConnectionClass.casino.SaveChanges();
        }
    }
}
