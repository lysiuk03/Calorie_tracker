using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _01_Calories.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace _01_Calories
{
    /// <summary>
    /// Interaction logic for Add_Food.xaml
    /// </summary>
    public partial class Add_Food : Window
    {
        FoodVievModel model = new();
        DateTime date;
        public Add_Food(DateTime Date)
        {
            InitializeComponent();
            DataContext = model;
            date= Date;
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            model.TextChanged();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            model.Add(date);
        }
    }
}
