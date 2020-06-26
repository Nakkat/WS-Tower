using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSTower.API.Interface;
using WSTower.API.Repository;

namespace WSTower.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogoRepository.ListarJogos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca todos os confrontos por data
        /// </summary>
        /// <param name="data"> Data dos confrontos a ser buscado </param>
        /// <returns> Uma lista de jogos e um status code 200 - Ok </returns>
        [HttpGet("BuscarPorData/{data}")]
        public IActionResult GetByDate(DateTime data)
        {
            return Ok(_jogoRepository.ListarPorData(data));
        }

        /// <summary>
        /// Busca todos os jogos por estádio
        /// </summary>
        /// <param name="estadio"> Nome do estádio dos confrontos a ser buscado </param>
        /// <returns> Uma lista de jogos e um status code 200 - Ok </returns>
        [HttpGet("BuscarPorEstadio/{estadio}")]
        public IActionResult GetByStadium(string estadio)
        {
            return Ok(_jogoRepository.ListarPorEstadio(estadio));
        }

        /// <summary>
        /// Busca todos os jogos por seleção
        /// </summary>
        /// <param name="selecao"> Nome da seleção dos confrontos a ser buscado </param>
        /// <returns> Uma lista de jogos e um status code 200 - Ok </returns>
        [HttpGet("BuscarPorSelecao/{selecao}")]
        public IActionResult GetByTeam(string selecao)
        {
            return Ok(_jogoRepository.ListarPorSelecao(selecao));
        }
        [HttpGet("data")]
        public IActionResult listarDatas()
        {
            return Ok(_jogoRepository.ListaDeDatas());
        }
    }
}
