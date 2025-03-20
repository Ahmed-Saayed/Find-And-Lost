using Lost_and_Found.Models.DTO;
using Lost_and_Found.Models.Entites;
using Lost_and_Found.Models;
using AutoMapper;
using Lost_and_Found.Interfaces;

namespace Lost_and_Found.Services
{
    public class FindPhoneService :IFindPhoneService
    {
        private DataConnection con;
        private IMapper mp;
        public FindPhoneService(DataConnection con, IMapper mp)
        {
            this.mp = mp;
            this.con = con;
        }

        public List<FindPhone> GetFoundedPhones()
        {
            return con.FindPhones.ToList();
        }

        public FindPhone GetFoundedPhoneOfNumber(string number)
        {
            return con.FindPhones.FirstOrDefault(o => o.PhoneNumber == number);
        }
        public FindPhone AddFoundedPhone(PhoneDTO phone)
        {
            if (con.LostPhones.FirstOrDefault(o => o.PhoneNumber == phone.PhoneNumber) != null)
                return null;

            using var stream = new MemoryStream();
            phone.PhonePhoto.CopyTo(stream);

            FindPhone phone1 = mp.Map<FindPhone>(phone);
            phone1.PhonePhoto = stream.ToArray();

            con.FindPhones.Add(phone1);
            con.SaveChanges();
            return phone1;
        }

        public string DeleteFoundedPhone(string phonenum)
        {
            if (con.FindPhones.FirstOrDefault(o => o.PhoneNumber == phonenum) == null)
                return null;

            con.FindPhones.Remove(con.FindPhones.FirstOrDefault(o => o.PhoneNumber == phonenum));
            con.SaveChanges();
            return $"Phone Number {phonenum} Deleted";
        }
    }
}
