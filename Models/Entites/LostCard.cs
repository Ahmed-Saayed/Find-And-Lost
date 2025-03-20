namespace Lost_and_Found.Models.Entites
{
    public class LostCard
    {
        public int Id { get; set; }
        public string CardID { get; set; }
        public byte[] CardPhoto { get; set; }
        public string Location { get; set; }
        public string ForiegnKey_UserEmail { get; set; }
        public User User { get; set; }                  // One To Many relation
    }
}
