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
        public async Task<List<string>> All_Card_Of_Email(string email)
        {
            List<string> lst = await con.LostCards.Where(o => o.ForiegnKey_UserEmail == email).Select(o => o.CardID).ToListAsync();

            List<string> ret = [];
            foreach (var item in lst)
                if ( await con.FindCards.AnyAsync(o => o.CardID == item))
                {
                    ret.Add(item);
                   
                }

            return ret;
        }

        public async Task<List<string>> All_Phone_Of_Email(string email)
        {
            List<string> lst = await con.LostPhones.Where(o => o.ForiegnKey_UserEmail == email).Select(o => o.PhoneNumber).ToListAsync();

            List<string> ret = [];
            foreach (var item in lst)
                if (await con.FindPhones.AnyAsync(o => o.PhoneNumber == item))
                {
                    ret.Add(item);
                   
                }

            return ret;
        }

    }
}