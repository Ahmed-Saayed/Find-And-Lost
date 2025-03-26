using Lost_and_Found.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lost_and_Found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Checking_For_ItemsController : ControllerBase
    {
        private readonly IChecking_For_Items checking_For_Items;
         public Checking_For_ItemsController(IChecking_For_Items checking_For_Items)
        {
            this.checking_For_Items = checking_For_Items;
        }

        [Authorize]
        [HttpGet("Get Cards by Email")]
        public IActionResult GetCards([FromForm]string email)
        {
            return Ok(checking_For_Items.All_Card_Of_Email(email));
        }

        [Authorize]
        [HttpGet("Get Phones by Email")]
        public IActionResult GetPhones([FromForm]string email)
        {
            return Ok(checking_For_Items.All_Phone_Of_Email(email));
        }
    }
}
