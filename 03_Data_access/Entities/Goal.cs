using _03_Data_access.Entities;

namespace _03_Data_access
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Coefficient { get; set; }
        public double Share_proteins { get; set; }
        public double Share_fats { get; set; }
        public double Share_carbs { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
    }

}
