using _03_Data_access;
using _03_Data_access.Entities;
using PropertyChanged;
using Syncfusion.Windows.Shared;
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
    /// Interaction logic for Change_Profile.xaml
    /// </summary>
    public partial class Change_Profile : Window
    {
        AccVievModel model;
        public Change_Profile()
        {
            InitializeComponent();
            model = new AccVievModel();
            DataContext = model;
            InfoComboBox();
        }
        void InfoComboBox()
        {
           activity_cb.ItemsSource = model.Activities;
            activity_cb.DisplayMemberPath = "Name";
            activity_cb.SelectedValuePath = "Id";
            goal_cb.ItemsSource = model.Goals;
            goal_cb.DisplayMemberPath = "Name";
            goal_cb.SelectedValuePath = "Id";
            activity_cb.SelectedValue = model.Acc.ActivityId;
           goal_cb.SelectedValue = model.Acc.GoalId;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model.Save();
            this.DialogResult = true;
            this.Close();
        }
    }
    [AddINotifyPropertyChangedInterface]
    class AccVievModel
    {
        CaloriesDbContext context = new CaloriesDbContext();
        public Accounts Acc { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Goal> Goals { get; set; }
        public AccVievModel()
        {
            Acc= context.Accounts.FirstOrDefault(a => a.Login == GlobalLogin.Instance.Login);
            Activities = context.Activity.ToList();
            Goals = context.Goal.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
          
        }
    }
}
