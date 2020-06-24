using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.API.Interface;
using WSTower.API.Repository;

namespace WSTower.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogadoresController : ControllerBase
    {
        private IJogadorRepository _jogadorRepository { get; set; }

        public JogadoresController()
        {
            _jogadorRepository = new JogadorRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogadorRepository.ListarJogadores());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
