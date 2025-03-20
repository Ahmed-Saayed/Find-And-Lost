using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;

namespace Lost_and_Found.Interfaces
{
    public interface ILostPhoneService
    {
        List<LostPhone> GetLostPhones();
        List<string> GetLostPhonesOfID(string email);
        LostPhone AddLostPhone(PhoneDTO lostPhone);
        string DeleteLostPhone(string email, string phonenum);
    }
}
