using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MyFrame.Content = new Login();
        }
        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            if (IsLog())
            {
                MyFrame.Content = new Day();
            }
        }

        private void Sing_out_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(GlobalLogin.Instance.Login))
            {
                GlobalLogin.Instance.Login = null;
                MyFrame.Content = new Login();
            }
            else
            {
                MessageBox.Show("You are not logged into an account yet.", "Not Logged In", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Sing_in_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(GlobalLogin.Instance.Login))
            {
                MessageBox.Show("Please log out first.", "Logged In", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MyFrame.Content = new Login();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if (IsLog())
            {
                MyFrame.Content = new Profile();
            }
        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            if (IsLog())
            {
                MyFrame.Content = new TableFood();
            }
        }
        bool IsLog()
        {
            if (string.IsNullOrEmpty(GlobalLogin.Instance.Login))
            {
                MessageBox.Show("Please log in first.", "Logged In", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }

}
