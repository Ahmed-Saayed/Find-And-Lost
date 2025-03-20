using AutoMapper;
using Lost_and_Found.Interfaces;
using Lost_and_Found.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lost_and_Found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lost_PhoneController : ControllerBase
    {
        private readonly ILostPhoneService lost_PhoneService;
        private readonly IMapper mp;
        public Lost_PhoneController(ILostPhoneService lost_PhoneService,IMapper mp)
        {
            this.lost_PhoneService = lost_PhoneService;
            this.mp = mp;
        }

        [HttpGet("Get All Losted Phones")]
        public IActionResult Get()
        {
            var lost_Phones = lost_PhoneService.GetLostPhones();
            var ret= mp.Map<List<PhoneDTO>>(lost_Phones);
            
            return Ok(ret);
        }

        [HttpGet("Get Losted Phones By Email")]
        public IActionResult Get([FromBody]string email)
        {
            var lost_Phones = lost_PhoneService.GetLostPhonesOfID(email);
            if (lost_Phones == null)
                return BadRequest("No Losted Phones Found");

            var ret = mp.Map<List<PhoneDTO>>(lost_Phones);

            return Ok(ret);
        }

        [HttpPost("Add Losted Phone")]
        public IActionResult Post([FromForm] PhoneDTO lostPhoneDTO)
        {
            var lostPhone = lost_PhoneService.AddLostPhone(lostPhoneDTO);
            if (lostPhone == null)
                return BadRequest("Phone Number Already Exists");

            var ret=mp.Map<PhoneDTO>(lostPhone);
            ret.UserEmail = lostPhone.ForiegnKey_UserEmail;
            return Ok(ret);
        }

        [HttpDelete("Delete Lost Phone")]
        public IActionResult Delete([FromBody] string email,string phonenum)
        {
            var ret = lost_PhoneService.DeleteLostPhone(email, phonenum);
            if (ret == null)
                return BadRequest("Phone Number Not Found");

            return Ok(ret);
        }

    }
}
