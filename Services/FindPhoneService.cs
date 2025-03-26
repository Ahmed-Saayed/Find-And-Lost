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

        public FindPhone AddFoundedPhone(FindPhoneDTO phone)
        {
            if (con.LostPhones.FirstOrDefault(o => o.PhoneNumber == phone.PhoneNumber) != null)
                return null;

            using var stream = new MemoryStream();
            phone.PhonePhoto?.CopyTo(stream);


            FindPhone phone1 = new()
            {
                PhoneNumber = phone.PhoneNumber,
                PhonePhoto = stream.ToArray(),
                Color = phone.Color,
                Brand = phone.Brand,
                Street = phone.Street,
                Government = phone.Government,
                Center = phone.Center,
            };
            con.FindPhones.Add(phone1);
            con.SaveChanges();
            return phone1;
        }
        public FindPhone UpdateFoundedPhone(FindPhoneDTO phone)
        {
            if (con.FindPhones.FirstOrDefault(o => o.PhoneNumber == phone.PhoneNumber) == null)
                return null;

            FindPhone phone1 =con.FindPhones.FirstOrDefault(o => o.PhoneNumber == phone.PhoneNumber);

            using var stream = new MemoryStream();
            phone.PhonePhoto?.CopyTo(stream);


            phone1.PhoneNumber = phone.PhoneNumber;
            phone1.PhonePhoto = stream.ToArray();
            phone1.Color = phone.Color;
            phone1.Brand = phone.Brand;
            phone1.Street = phone.Street;
            phone1.Center = phone.Center;
            phone1.Government = phone.Government;
            
            con.FindPhones.Update(phone1);
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
