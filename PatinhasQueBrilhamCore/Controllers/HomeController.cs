using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilham.Service.Home;

namespace PatinhasQueBrilham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly PatinhasContext _context;

        public HomeController(PatinhasContext context)
        {
            _context = context;
        }

        [HttpGet("GetCapas")]
        public IActionResult GetCapas()
        {
            try
            {
                HomeService homeService = new HomeService(this._context);
                homeService.findCapas();

                if (homeService._capas != null)
                    return Ok(homeService._capas);
                else
                    return BadRequest(new { message = "Nenhuma capa encontrada" });
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
