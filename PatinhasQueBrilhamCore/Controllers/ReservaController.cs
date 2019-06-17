using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilham.Service;

namespace PatinhasQueBrilham.Controllers
{
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {

        private readonly PatinhasContext _context;
        public ReservaController(PatinhasContext context)
        {
            _context = context;
        }

        // POST: api/Reserva
        [HttpPost("[action]")]
        public IActionResult Reservar([FromBody] Reserva reserva)
        {
            try
            {
                ReservaService reservaService = new ReservaService(_context);
                reservaService.Salvar(reserva);
                reservaService.EnviarEmailReserva(reserva);

                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public IActionResult PesquisarReserva([FromHeader] Reserva reserva)
        {
            try
            {
                ReservaService reservaService = new ReservaService(this._context);
                reservaService.BuscarReserva(reserva);
                return Ok(reservaService._reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("[action]")]
        public IActionResult AtualizarReserva([FromBody] Reserva reserva)
        {
            try
            {
                ReservaService reservaService = new ReservaService(this._context);
                reservaService.AtualizarReserva(reserva);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("[action]")]
        public IActionResult EnviarEmailAtualizacaoReserva([FromBody] Reserva reserva)
        {
            try
            {
                ReservaService reservaService = new ReservaService(this._context);
                reservaService.EnviarEmailAlteracao(reserva);

                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("[action]")]
        public IActionResult CancelarReserva([FromBody] Reserva reserva)
        {
            try
            {
                ReservaService reservaService = new ReservaService(this._context);
                reservaService.CancelarReserva(reserva);
                reservaService.EnviarEmailCancelamento(reserva);

                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
