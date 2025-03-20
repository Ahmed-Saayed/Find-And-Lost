using AutoMapper;
using Lost_and_Found.Interfaces;
using Lost_and_Found.Models;
using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;

namespace Lost_and_Found.Services
{
    public class LostPhoneService : ILostPhoneService
    {
        private DataConnection con;
        private IMapper mp;
        public LostPhoneService(DataConnection con, IMapper mp)
        {
            this.con = con;
            this.mp=mp;
        }

        public List<LostPhone> GetLostPhones()
        {
            return con.LostPhones.ToList();
        }

        public List<string> GetLostPhonesOfID(string email)
        {
            return con.LostPhones.Where(o => o.ForiegnKey_UserEmail == email).Select(o => o.PhoneNumber).ToList();
        }
        public LostPhone AddLostPhone(PhoneDTO lostPhoneDTO)
        {
            if (con.LostPhones.FirstOrDefault(o => o.PhoneNumber == lostPhoneDTO.PhoneNumber) != null)
                return null;
            /*
            using var stream = new MemoryStream();
            lostPhoneDTO.PhonePhoto.CopyTo(stream);
            */
            LostPhone lostphone = new()
            {
                PhoneNumber = lostPhoneDTO.PhoneNumber,
                ForiegnKey_UserEmail = lostPhoneDTO.UserEmail,
                //PhonePhoto = lostPhoneDTO.PhonePhoto
                Location = lostPhoneDTO.Location
            };

            con.LostPhones.Add(lostphone);
            con.SaveChanges();

            return lostphone;
        }

        public string DeleteLostPhone(string email,string phonenum)
        {
            if (con.LostPhones.FirstOrDefault(o => o.ForiegnKey_UserEmail == email) == null
                || con.LostPhones.FirstOrDefault(o => o.PhoneNumber == phonenum) == null)
                return null;

            con.LostPhones.Remove(con.LostPhones.FirstOrDefault(o => o.PhoneNumber == phonenum));
            con.SaveChanges();
            return $"Phone Number {phonenum} Deleted";
        }
    }
}
