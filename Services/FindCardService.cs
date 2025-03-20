using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;
using Lost_and_Found.Models;
using AutoMapper;
using Lost_and_Found.Interfaces;

namespace Lost_and_Found.Services
{
    public class FindCardService : IFindCardService
    {
            private DataConnection con;
            private IMapper mp;
            public FindCardService(DataConnection con, IMapper mp)
            {
                this.con = con;
                this.mp = mp;
            }

            public List<FindCard> GetFoundedCards()
            {
                return con.FindCards.ToList();
            }

            public FindCard GetFoundedCardOfID(string cardid)
            {
                return con.FindCards.FirstOrDefault(o => o.CardID == cardid);
            }
            public FindCard AddFoundedCard(CardsDTO card)
            {
                if (con.FindCards.FirstOrDefault(o => o.CardID == card.CardID) != null)
                    return null;

                using var stream = new MemoryStream();
                card.CardPhoto.CopyTo(stream);

                var card1 = mp.Map<FindCard>(card);

               card1.CardPhoto = stream.ToArray();

                con.FindCards.Add(card1);
            con.SaveChanges();

            return card1;
            }

            public string DeleteFoundedCard(string card)
            {
                if (con.FindCards.FirstOrDefault(o => o.CardID == card) == null)
                    return null;

                con.FindCards.Remove(con.FindCards.FirstOrDefault(o => o.CardID == card));
                con.SaveChanges();
                return $"Card Number {card} Deleted";
            }
        }
}
