namespace _03_Data_access.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Coefficient { get; set; }
        
        public ICollection<Accounts> Accounts { get; set; }
    }

}
