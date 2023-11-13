using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [Route("api/[controller]")]    
    public class DinnersController : ApiBaseController
    {
        [HttpGet]
        public IActionResult ListDinner()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
