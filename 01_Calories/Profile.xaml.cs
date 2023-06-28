using _03_Data_access;
using _03_Data_access.Entities;
using System;
using System.Linq;
using System.Windows.Controls;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Accounts Acc { get; set; }
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
        public Profile()
        {
            InitializeComponent();
            DataContext = this;
            CaloriesDbContext context = new CaloriesDbContext();
            Acc = context.Accounts.FirstOrDefault(a => a.Login == GlobalLogin.Instance.Login);
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
