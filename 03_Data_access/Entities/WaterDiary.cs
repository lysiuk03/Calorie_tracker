namespace _03_Data_access.Entities
{
    public class WaterDiary
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int Portion { get; set; }
        public DateTime Date { get; set; }
        public Accounts Account { get; set; }
    }

}
