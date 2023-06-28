using _03_Data_access;
using _03_Data_access.Entities;
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

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for New_account.xaml
    /// </summary>
    public partial class New_account : Window
    {
        CaloriesDbContext context = new CaloriesDbContext();
        public New_account()
        {
            InitializeComponent();
            InfoComboBox();
        }
        void InfoComboBox()
        {
            sex_cb.ItemsSource = context.Sex.ToList();
            sex_cb.DisplayMemberPath = "Name";
            sex_cb.SelectedIndex = 0;
            activity_cb.ItemsSource = context.Activity.ToList();
            activity_cb.DisplayMemberPath = "Name";
            activity_cb.SelectedIndex = 0;
            goal_cb.ItemsSource = context.Goal.ToList();
            goal_cb.DisplayMemberPath = "Name";
            goal_cb.SelectedIndex = 0;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string login = log_tb.Text;
            string password = pass_pb.Password;
            int age = Convert.ToInt32(age_ud.Value);
            Sex selectedSex = (Sex)sex_cb.SelectedItem;
            int height = Convert.ToInt32(height_ud.Value);
            double weight = Convert.ToDouble(weight_ud.Value);
            Activity selectedActivity = (Activity)activity_cb.SelectedItem;
            Goal selectedGoal = (Goal)goal_cb.SelectedItem;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || age ==0 || height == 0 || weight == 0)
            {
                MessageBox.Show("Please fill in all the fields.", "Incomplete Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if ( age < 6 || height< 75 || weight < 15 || age > 120 || height > 275 || weight > 360)
            {
                MessageBox.Show("Incorrect weight/height or age entered.", "Incomplete Fields", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Accounts newAccount = new Accounts()
            {
                Login = login,
                Password = password,
                Age = age,
                Sex = selectedSex,
                Height = height,
                Weight = weight,
                Activity = selectedActivity,
                Goal = selectedGoal
            };

            context.Accounts.Add(newAccount);

            try
            {
                context.SaveChanges();
                MessageBox.Show("Account saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the account: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
