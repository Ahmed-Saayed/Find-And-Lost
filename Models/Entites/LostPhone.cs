namespace Lost_and_Found.Models.Entites
{
    public class LostPhone
    {
        public int ID { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? PhonePhoto { get; set; }
        public string Location { get; set; }
        public string ForiegnKey_UserEmail { get; set; }
        public User User { get; set; }                      // One To Many relation
    }
}
