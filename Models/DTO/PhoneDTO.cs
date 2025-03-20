namespace Lost_and_Found.Models.DTO
{
    public class PhoneDTO
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile? PhonePhoto { get; set; }
        public string Location { get; set; }
        public string UserEmail { get; set; }
    }
}
