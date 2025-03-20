using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;

namespace Lost_and_Found.Interfaces
{
    public interface IFindPhoneService
    {
        List<FindPhone> GetFoundedPhones();
        FindPhone GetFoundedPhoneOfNumber(string number);
        FindPhone AddFoundedPhone(PhoneDTO lostPhone);
        string DeleteFoundedPhone(string phonenum);
    }
}
