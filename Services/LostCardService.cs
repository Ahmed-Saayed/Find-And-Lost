using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;
using Lost_and_Found.Models;
using AutoMapper;
using Lost_and_Found.Interfaces;

namespace Lost_and_Found.Services
{
    public class LostCardService:ILostCardService
    {
        private DataConnection con;
        private IMapper mp;
        public LostCardService(DataConnection con, IMapper mp)
        {
            this.con = con;
            this.mp = mp;
        }

        public List<LostCard> GetLostCards()
        {
            return con.LostCards.ToList();
        }

        public List<string> GetLostPhonesOfEmail(string email)
        {
            return con.LostCards.Where(o => o.ForiegnKey_UserEmail == email).Select(o => o.CardID).ToList();
        }
        public LostCard AddLostCard(LostCardsDTO lostCardDTO)
        {
            if (con.LostCards.FirstOrDefault(o => o.CardID == lostCardDTO.CardID) != null)
                return null;

            using var stream = new MemoryStream();
            lostCardDTO.CardPhoto?.CopyTo(stream);


            LostCard lostcard = new()
            {
                CardID = lostCardDTO.CardID,
                CardPhoto = stream.ToArray(),
                Street = lostCardDTO.Street,
                Center = lostCardDTO.Center,
                Government = lostCardDTO.Government,
                ForiegnKey_UserEmail = lostCardDTO.ForiegnKey_UserEmail
            };

            con.LostCards.Add(lostcard);
            con.SaveChanges();

            return lostcard;
        }

        public LostCard UpdateLostCard(LostCardsDTO card)
        {
            if (con.LostCards.FirstOrDefault(o => o.CardID == card.CardID) == null)
                return null;

            LostCard card1 = con.LostCards.FirstOrDefault(o => o.CardID == card.CardID);

            using var stream = new MemoryStream();
            card.CardPhoto?.CopyTo(stream);


            card1.CardID = card.CardID;
            card1.CardPhoto = stream.ToArray();
            card1.Street = card.Street;
            card1.Center = card.Center;
            card1.Government = card.Government;

            con.LostCards.Update(card1);
            con.SaveChanges();

            return card1;
        }

        public string DeleteLostCard(string email, string cardid)
        {
            if (con.LostCards.FirstOrDefault(o => o.ForiegnKey_UserEmail == email) == null
                || con.LostCards.FirstOrDefault(o => o.CardID == cardid) == null)
                return null;

            con.LostCards.Remove(con.LostCards.FirstOrDefault(o => o.CardID == cardid));
            con.SaveChanges();
            return $"Card Number {cardid} Deleted";
        }
    }
}
