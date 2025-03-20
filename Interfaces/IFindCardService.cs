using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;

namespace Lost_and_Found.Interfaces
{
    public interface IFindCardService
    {
        List<FindCard> GetFoundedCards();
        FindCard GetFoundedCardOfID(string cardid);
        FindCard AddFoundedCard(CardsDTO card);
        string DeleteFoundedCard(string cardid);
    }
}
