namespace Lost_and_Found.Interfaces
{
    public interface IChecking_For_Items
    {
        public Task<List<string>> All_Phone_Of_Email(string email);
        public Task<List<string>> All_Card_Of_Email(string email);

    }
}