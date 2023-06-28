namespace _03_Data_access.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public int Calories { get; set; }
        public ICollection<FoodDiary>  FoodDiaries { get; set; }
    }

}
