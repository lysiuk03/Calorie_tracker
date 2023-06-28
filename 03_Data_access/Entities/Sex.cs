namespace _03_Data_access.Entities
{
    public class Sex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
    }

}
