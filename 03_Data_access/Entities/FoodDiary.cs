namespace _03_Data_access.Entities
{
    public class FoodDiary
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int FoodId { get; set; }
        public DateTime Date { get; set; }
        public int Portion { get; set; }
        public Accounts Account { get; set; }
        public Food Food { get; set; }
    }

}
