namespace Lost_and_Found.Models.DTO
{
    public class CardsDTO
    {
        public int Id { get; set; }
        public string CardID { get; set; }
        public IFormFile CardPhoto { get; set; }
        public string Location { get; set; }
        public string UserEmail { get; set; }
    }
}
