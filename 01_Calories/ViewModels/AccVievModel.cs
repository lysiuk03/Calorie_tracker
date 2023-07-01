using _03_Data_access;
using _03_Data_access.Entities;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;

namespace _01_Calories.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class AccVievModel
    {
        CaloriesDbContext context = new CaloriesDbContext();
        public Accounts Acc { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Goal> Goals { get; set; }
        public AccVievModel()
        {
            Acc = context.Accounts.FirstOrDefault(a => a.Login == GlobalLogin.Instance.Login);
            Activities = context.Activity.ToList();
            Goals = context.Goal.ToList();
        }
        public void Save()
        {
            context.SaveChanges();

        }
    }
}
