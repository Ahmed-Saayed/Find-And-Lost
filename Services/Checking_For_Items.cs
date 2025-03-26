using Lost_and_Found.Interfaces;
using Lost_and_Found.Models;
using Microsoft.EntityFrameworkCore;

namespace Lost_and_Found.Services
{
    public class Checking_For_Items : IChecking_For_Items
    {
        private readonly DataConnection con;
        public Checking_For_Items(DataConnection con)
        {
            this.con = con;
        }
        public List<string> All_Card_Of_Email(string email)
        {
            List<string> lst = con.LostCards.Where(o => o.ForiegnKey_UserEmail == email).Select(o => o.CardID).ToList();

            List<string> ret = [];
            foreach (var item in lst)
                if (con.FindCards.Any(o => o.CardID == item))
                {
                    ret.Add(item);
                    con.LostCards.Remove(con.LostCards.FirstOrDefault(o => o.CardID == item));
                    con.SaveChanges();
                }

            return ret;
        }

        public List<string> All_Phone_Of_Email(string email)
        {
            List<string> lst = con.LostPhones.Where(o => o.ForiegnKey_UserEmail == email).Select(o => o.PhoneNumber).ToList();

            List<string> ret = [];
            foreach (var item in lst)
                if (con.FindPhones.Any(o => o.PhoneNumber == item))
                {
                    ret.Add(item);
                    con.LostPhones.Remove(con.LostPhones.FirstOrDefault(o => o.PhoneNumber == item));
                    con.SaveChanges();
                }

            return ret;
        }

    }
}
