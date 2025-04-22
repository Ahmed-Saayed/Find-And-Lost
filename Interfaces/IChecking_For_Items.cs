namespace Lost_and_Found.Interfaces
{
    public interface IChecking_For_Items
    {
        public Task<List<string>> All_Items(string email);

    }
}