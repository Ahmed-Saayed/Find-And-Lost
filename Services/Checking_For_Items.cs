using Lost_and_Found.Interfaces;
using Lost_and_Found.Models;
using Lost_and_Found.Models.Entites;
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
        public async Task<List<string>> All_Items(string email)
        {
            List<LostCard> lst = await con.LostCards.Where(o => o.ForiegnKey_UserEmail == email).ToListAsync();

            List<string> ret = [];
            foreach (var item in lst)
                if ( await con.FindCards.AnyAsync(o => o.CardID == item.CardID))
                {
                    ret.Add("found Card with ID = " + item.CardID + " === Email of the finder = "
                        + con.FindCards.FirstOrDefault(o => o.CardID == item.CardID).FinderEmail);  
                }

            List<LostPhone> lst2 = await con.LostPhones.Where(o => o.ForiegnKey_UserEmail == email).ToListAsync();

            foreach (var item in lst2)
                if (await con.FindPhones.AnyAsync(o => o.PhoneNumber == item.PhoneNumber))
                {
                    ret.Add("found Phone with ID = " + item.PhoneNumber + " === Email of the finder = " 
                        +  con.FindPhones.FirstOrDefault(o => o.PhoneNumber == item.PhoneNumber).FinderEmail);
                }

            return  ret;
        }
    }
}