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

            public FindCard AddFoundedCard(FindCardDTO card)
            {
                if (con.FindCards.FirstOrDefault(o => o.CardID == card.CardID) != null)
                    return null;

            FindCard card1 = new()
            {
                CardID = card.CardID,
                Street = card.Street,
                Government = card.Government,
                Center = card.Center,
            };

            con.FindCards.Add(card1);
                con.SaveChanges();

            return card1;
            }

        public FindCard UpdateFoundedCard(FindCardDTO card)
        {
            if (con.FindCards.FirstOrDefault(o => o.CardID == card.CardID) == null)
                return null;

            FindCard card1 = con.FindCards.FirstOrDefault(o => o.CardID == card.CardID);

            card1.CardID = card.CardID;
            card1.Street = card.Street;
            card1.Government = card.Government;
            card1.Center = card.Center;
           

            con.FindCards.Update(card1);
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
