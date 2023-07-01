using System;
using System.Windows.Controls;
using _01_Calories.ViewModels;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>

    public partial class Profile : Page
    {
        public ProfileViewModel Model { get; set; }

        public Profile()
        {
            InitializeComponent();
            Model= new ProfileViewModel();
            DataContext = Model;
        }
        private void Change_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Change_Profile change = new Change_Profile();
            change.ShowDialog();

            if (change.DialogResult == true)
            {
                Model = new ProfileViewModel();
                DataContext = Model;
            }
        }
    }
}
