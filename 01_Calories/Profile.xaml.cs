using _03_Data_access;
using _03_Data_access.Entities;
using PropertyChanged;
using System;
using System.Linq;
using System.Windows.Controls;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
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
    public class ProfileViewModel
    {
        CaloriesDbContext context = new CaloriesDbContext();
        private Accounts acc;
        public Accounts Acc
        {
            get { return acc; }
            set
            {
                acc = value;
                Init();
            }
        }
        public string Sex { get; set; }
        public Activity Activity { get; set; }
        public Goal Goal { get; set; }
        public int BMRValue { get; set; }
        public int Daily_rate { get; set; }
        public int Goal_norm { get; set; }
        public int Proteins_norm { get; set; }
        public int Fats_norm { get; set; }
        public int Carbs_norm { get; set; }
        public int Water_norm { get; set; }
        public ProfileViewModel()
        {
            Acc = context.Accounts.FirstOrDefault(a => a.Login == GlobalLogin.Instance.Login);
        }
        void Init()
        {
            Sex = (context.Sex.FirstOrDefault(s => s.Id == Acc.SexId)).Name;
            Activity = context.Activity.FirstOrDefault(a => a.Id == Acc.ActivityId);
            Goal = context.Goal.FirstOrDefault(g => g.Id == Acc.GoalId);
            BMRValue = (int)BMR(Sex);
            Daily_rate = (int)(BMRValue * Activity.Coefficient);
            Goal_norm = (int)(Daily_rate * Goal.Coefficient);
            Water_norm = (int)(Acc.Weight * 30);
            Proteins_norm = (int)((Goal_norm * Goal.Share_proteins) / 4);
            Fats_norm = (int)((Goal_norm * Goal.Share_fats) / 4);
            Carbs_norm = (int)((Goal_norm * Goal.Share_carbs) / 9);
        }
        double BMR(string sex)//базовий метаболізм
        {
            double bmr = 0;
            if (Acc.Sex.Name != null)
            {
                if (sex == "Male")
                {
                    bmr = 88.362 + (13.397 * Acc.Weight) + (4.799 * Acc.Height) - (5.677 * Acc.Age);
                }
                if (sex == "Female")
                {
                    bmr = 447.593 + (9.247 * Acc.Weight) + (3.098 * Acc.Height) - (4.330 * Acc.Age);
                }
            }
            return bmr;
        }
    }
}
