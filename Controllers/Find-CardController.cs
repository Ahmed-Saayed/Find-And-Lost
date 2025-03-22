using AutoMapper;
using Lost_and_Found.Interfaces;
using Lost_and_Found.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lost_and_Found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Find_CardController : ControllerBase
    {

        private readonly IFindCardService Find_CardServices;
        private readonly IMapper mp;
        public Find_CardController(IFindCardService lost_CardService, IMapper mp)
        {
            this.Find_CardServices = lost_CardService;
            this.mp = mp;
        }
        [Authorize(Roles = "Manager")]
        [HttpGet("Get All Founded Cards")]
        public IActionResult Get()
        {
            var lost_Cards = Find_CardServices.GetFoundedCards();
            List<FindCardDTO> ret = new();
            foreach (var card in lost_Cards)
                ret.Add(new FindCardDTO {CardID =card.CardID,Street = card.Street,Center=card.Center,Government=card.Government});

            return Ok(ret);
        }
        [Authorize]
        [HttpPost("Add find Card")]
        public IActionResult Post([FromForm] FindCardDTO findCardDTO)
        {
            var findcard = Find_CardServices.AddFoundedCard(findCardDTO);
            if (findcard == null)
                return BadRequest("Card Number Already Exists");

            var ret = new FindCardDTO
            {
                CardID = findcard.CardID,
                Government  = findcard.Government,
                Street = findcard.Street,
                Center = findcard.Center
            };

            return Ok(ret);
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("Update Losted Card")]
        public IActionResult Update([FromForm] FindCardDTO lostCardDTO)
        {
            var findcard = Find_CardServices.UpdateFoundedCard(lostCardDTO);
            if (findcard == null)
                return BadRequest("Card Number do not Exists");

            var ret = new FindCardDTO
            {
                CardID = findcard.CardID,
                Government = findcard.Government,
                Street = findcard.Street,
                Center = findcard.Center
            };

            return Ok(findcard);
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("Delete find Card")]
        public IActionResult Delete( [FromForm] string cardid)
        {
            var ret = Find_CardServices.DeleteFoundedCard(cardid);
            if (ret == null)
                return BadRequest("Card Number Not Found");

            return Ok(ret);
        }
    }
}
