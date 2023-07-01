using System.Windows;
using System.Windows.Controls;
using _01_Calories.ViewModels;

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

}
