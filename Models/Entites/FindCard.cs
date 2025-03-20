namespace Lost_and_Found.Models.Entites
{
    public class FindCard
    {
        public int Id { get; set; }
        public string CardID { get; set; }
        public byte[] CardPhoto { get; set; }
        public string Location { get; set; }
    }
}
