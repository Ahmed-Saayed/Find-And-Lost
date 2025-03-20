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
        public LostCard AddLostCard(CardsDTO lostCardDTO)
        {
            if (con.LostCards.FirstOrDefault(o => o.CardID == lostCardDTO.CardID) != null)
                return null;

            /*
            using var stream = new MemoryStream();
            lostCardDTO.CardPhoto.CopyTo(stream);
            */
            var lostcard = mp.Map<LostCard>(lostCardDTO);

            //lostcard.CardPhoto=stream.ToArray();
            con.LostCards.Add(lostcard);
            con.SaveChanges();

            return lostcard;
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
