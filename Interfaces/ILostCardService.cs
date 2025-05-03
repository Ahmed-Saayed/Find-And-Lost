using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;

namespace Lost_and_Found.Interfaces
{
    public interface ILostCardService
    {
        List<LostCard> GetLostCards();
        List<string> GetLostPhonesOfEmail(string email);
        public LostCard AddLostCard(LostCardsDTO lostCard);
        LostCard UpdateLostCard(LostCardsDTO card);
        public string DeleteLostCard( string CardID);
    }
}
