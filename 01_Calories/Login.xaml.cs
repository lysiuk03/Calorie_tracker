using _03_Data_access;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page 
    {
        CaloriesDbContext context;
        public Login()
        {
            InitializeComponent();
            context = new CaloriesDbContext();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            string login = log.Text;
            string password = pass.Password;

            var account = context.Accounts.FirstOrDefault(a => a.Login == login && a.Password == password);
            if (account != null)
            {
                GlobalLogin.Instance.Login = account.Login;
                MessageBox.Show("Log in successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Eror.", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_account_Click(object sender, RoutedEventArgs e)
        {
            New_account account = new New_account();
            account.ShowDialog();
        }
    }
}
