using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilham.Service.Footer;

namespace PatinhasQueBrilham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly PatinhasContext _context;

        public FooterController(PatinhasContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IActionResult getApoios()
        {
            try
            {
                FooterService footerService = new FooterService(this._context);
                footerService.GetApoios();

                return Ok(footerService.apoios);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
