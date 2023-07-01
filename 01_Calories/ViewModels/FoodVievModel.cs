using _03_Data_access;
using _03_Data_access.Entities;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace _01_Calories.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class FoodVievModel
    {
        CaloriesDbContext context = new CaloriesDbContext();
        ObservableCollection<Food> AllFood;
        public ObservableCollection<Food> FoodList { get; set; }
        public Food Food { get; set; }
        public string Portion { get; set; }
        public string Str { get; set; }
        public FoodVievModel()
        {
            AllFood = new ObservableCollection<Food>(context.Food.ToList());
            FoodList = new ObservableCollection<Food>(AllFood);
        }
        public void TextChanged()
        {
            if (Str != null)
            {
                var filteredList = AllFood.Where(f => f.Name.ToLower().StartsWith(Str));
                FoodList.Clear();
                foreach (var food in filteredList)
                {
                    FoodList.Add(food);
                }
            }
            else
            {
                FoodList.Clear();
                foreach (var food in AllFood)
                {
                    FoodList.Add(food);
                }
                MessageBox.Show("Empty!");
            }
        }
        public void Add(DateTime date)
        {
            int portion;
            bool isInteger = int.TryParse(Portion, out portion) && portion > 0;

            if (isInteger)
            {
                if (Food != null)
                {
                    FoodDiary foodDiary = new FoodDiary
                    {
                        AccountId = GlobalLogin.Instance.Login,
                        FoodId = Food.Id,
                        Date = date,
                        Portion = int.Parse(Portion)
                    };
                    context.FoodDiary.Add(foodDiary);
                    context.SaveChanges();
                    MessageBox.Show("Food added!", "Added", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Fill in all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter the portion weight correctly!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
