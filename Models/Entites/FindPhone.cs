namespace Lost_and_Found.Models.Entites
{
    public class FindPhone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Color { get; set; }
        public byte[] PhonePhoto { get; set; }
        public string Location { get; set; }
    }
}
