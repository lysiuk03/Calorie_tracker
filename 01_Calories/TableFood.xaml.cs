using _03_Data_access;
using _03_Data_access.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for TableFood.xaml
    /// </summary>
    public partial class TableFood : Page
    {
        CaloriesDbContext context = new CaloriesDbContext();
        public TableFood()
        {
            InitializeComponent();
            Foods.ItemsSource = context.Food.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(name_tb.Text))
            {
                if (proteins_ud.Value >= 0 && fats_ud.Value > 0 && carbs_ud.Value > 0 && calories_ud.Value > 0)
                {
                    Food newfood = new Food
                    {
                        Name = name_tb.Text,
                        Proteins = (double)proteins_ud.Value,
                        Fats = (double)fats_ud.Value,
                        Carbs = (double)carbs_ud.Value,
                        Calories = (int)calories_ud.Value
                    };
                    context.Food.Add(newfood);
                    MessageBox.Show("Food added.", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect data entered.", "Invalid", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            context.SaveChanges();
            Foods.ItemsSource = context.Food.ToList();
        }
    }
}
