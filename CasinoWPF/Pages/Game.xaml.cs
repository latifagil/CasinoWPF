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
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game(string login, string password)
        {
            InitializeComponent();

            loginObj = ConnectionClass.casino.Login.FirstOrDefault(log => log.Email == login && log.Password == password);
            userObj = ConnectionClass.casino.Users.FirstOrDefault(log => log.LoginID == loginObj.LoginID);

        }
        Login loginObj;
        Users userObj;
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        Random random = new Random();
      
         
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumberRandom.Text) || string.IsNullOrEmpty(BetRandom.Text))
            {
                MessageBox.Show("All fiels must be filled!");
                return;
            }
            if (Convert.ToInt32(NumberRandom.Text) > 10 || Convert.ToInt32(NumberRandom.Text) < 1 || Convert.ToDecimal(BetRandom.Text)>= userObj.Balance)
            {
                MessageBox.Show("Number must be 1-10, Bet must be less or equal ti balance!");
                return;
            }

            int x = random.Next(1, 11);
            number.Text = Convert.ToString (x);
            if (x == Convert.ToInt32(NumberRandom.Text))
            {
                MessageBox.Show("You win", Convert.ToString(Convert.ToDecimal(BetRandom.Text) * 2));
                userObj.Balance += Convert.ToDecimal(BetRandom.Text) * 2;
                return;
            }

            MessageBox.Show("You lose", BetRandom.Text);
            userObj.Balance -= Convert.ToDecimal(BetRandom.Text);
        }
    }
}
