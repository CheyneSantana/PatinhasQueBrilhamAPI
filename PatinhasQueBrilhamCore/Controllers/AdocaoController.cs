using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatinhasQueBrilham.DTO;
using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilham.Service;
using ViaCEP;

namespace PatinhasQueBrilham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdocaoController : ControllerBase
    {
        private readonly PatinhasContext _context;
        private IMapper _mapper;
        public AdocaoController(PatinhasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public IActionResult getAnimaisAdocao()
        {
            try
            {
                AdocaoService adocaoService = new AdocaoService(this._context);
                adocaoService.FindAnimaisAdocao();
                if (adocaoService.animais != null)
                    return Ok(adocaoService.animais);
                else
                    return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public IActionResult getAllAnimais()
        {
            try
            {
                AdocaoService adocaoService = new AdocaoService(this._context);
                adocaoService.FindAllAnimais();
                if (adocaoService.animais != null)
                    return Ok(adocaoService.animais);
                else
                    return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public IActionResult getNomeAnimal([FromHeader]AnimaisAdocao animal)
        {
            try
            {
                AdocaoService adocaoService = new AdocaoService(this._context);
                adocaoService.findNomeAnimal(animal.NomeAtual);
                if (adocaoService.animais != null)
                    return Ok(adocaoService.animais);
                else
                    return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("[action]")]
        public IActionResult EnviarSolicitacao([FromBody]FormularioDTO formulario)
        {
            try
            {
                AdocaoService adocaoService = new AdocaoService(this._context);
                adocaoService.EnviarFormularioAdocao(formulario, this._mapper);

                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public IActionResult BuscarCep([FromHeader]ViaCEPResult viaCEPResult)
        {
            try
            {
                AdocaoService adocaoService = new AdocaoService(this._context);
                adocaoService.FindCep(viaCEPResult.ZipCode);

                return Ok(adocaoService.viaCEPResult);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
