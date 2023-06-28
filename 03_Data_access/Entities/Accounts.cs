using System.ComponentModel.DataAnnotations;

namespace _03_Data_access.Entities
{
    public partial class Accounts
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int SexId { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public int ActivityId { get; set; }
        public int GoalId { get; set; }
        public Activity Activity { get; set; }
        public Sex Sex { get; set; }
        public Goal Goal { get; set; }
        public ICollection<FoodDiary>  FoodDiaries { get; set; }
        public ICollection<WaterDiary> WaterDiaries { get; set; }
    }

}
