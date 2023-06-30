using _03_Data_access;
using _03_Data_access.Entities;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for Day.xaml
    /// </summary>
    public partial class Day : Page
    {
        VievModel _model;
        public Day()
        {
            InitializeComponent();
            _model = new VievModel();
            DataContext = _model;
        }

        private void Water_add_Click(object sender, RoutedEventArgs e)
        {
            _model.AddWater(50);
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            _model.Change_Date(-1);
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            _model.Change_Date(1);
        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            Add_Food food = new Add_Food(_model.Date);
            food.ShowDialog();
            _model.Is_Calories();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _model.Delete();
        }
    }
    [AddINotifyPropertyChangedInterface]
    class VievModel
    {
        CaloriesDbContext context = new CaloriesDbContext();
        public List<FoodDiary> FoodDiary { get; set; }
        public FoodDiary SelFoodDiary { get; set; }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                Is_Water();
                Is_Calories();
            }
        }

        public int Water_norm { get; set; }
        public int Calories_norm { get; set; }
        public double Proteins_norm { get; set; }
        public double Fats_norm { get; set; }
        public double Carbs_norm { get; set; }

        public int Water_is { get; set; }
        public int Calories_is { get; set; }
        public double Proteins_is { get; set; }
        public double Fats_is { get; set; }
        public double Carbs_is { get; set; }

        public VievModel()
        {
            Date = DateTime.Now;
            Profile profile = new Profile();
            Water_norm = profile.Model.Water_norm;
            Is_Water();
            Is_Calories();
            Calories_norm = profile.Model.Goal_norm;
            Proteins_norm = profile.Model.Proteins_norm;
            Fats_norm = profile.Model.Fats_norm;
            Carbs_norm = profile.Model.Carbs_norm;
        }
        public void AddWater(int portion)
        {
            WaterDiary waterDiary = new WaterDiary
            {
                AccountId = GlobalLogin.Instance.Login,
                Portion = portion,
                Date = Date
            };
            context.WaterDiary.Add(waterDiary);
            context.SaveChanges();
            Is_Water();
        }
        void Is_Water()
        {
            Water_is = context.WaterDiary.Where(w => w.AccountId == GlobalLogin.Instance.Login && w.Date.Date == Date.Date).Sum(w => w.Portion);
        }
        public void Is_Calories()
        {
            FoodDiary = context.FoodDiary.Where(f => f.AccountId == GlobalLogin.Instance.Login && f.Date.Date == Date.Date).ToList();
            Calories_is = FoodDiary.Sum((f => context.Food.FirstOrDefault(food => food.Id == f.FoodId).Calories * f.Portion / 100));
            Proteins_is = Math.Round(FoodDiary.Sum(f => context.Food.FirstOrDefault(food => food.Id == f.FoodId).Proteins * f.Portion / 100), 1);
            Fats_is = Math.Round(FoodDiary.Sum(f => context.Food.FirstOrDefault(food => food.Id == f.FoodId).Fats * f.Portion / 100), 1);
            Carbs_is = Math.Round(FoodDiary.Sum(f => context.Food.FirstOrDefault(food => food.Id == f.FoodId).Carbs * f.Portion / 100), 1);

        }
        public void Change_Date(int x)
        {
            Date = Date.AddDays(x);
        }
        public void Delete()
        {
            if(SelFoodDiary!=null)
            {
                context.FoodDiary.Remove(SelFoodDiary);
                MessageBox.Show("Yep");
                context.SaveChanges();
                Is_Calories();
            }
            else
            {
                MessageBox.Show("No");
            }
        }
    }

}
