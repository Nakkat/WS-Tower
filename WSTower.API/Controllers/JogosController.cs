using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSTower.API.Domains;
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

        /// <summary>
        /// Busca todos os confrontos por ordem de datas
        /// </summary>
        /// <returns> Uma lista de jogos e um status code 200 - Ok </returns>
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
            try
            {
                return Ok(_jogoRepository.ListarPorData(data));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca todos os jogos por estádio
        /// </summary>
        /// <param name="estadio"> Nome do estádio dos confrontos a ser buscado </param>
        /// <returns> Uma lista de jogos e um status code 200 - Ok </returns>
        [HttpGet("BuscarPorEstadio/{estadio}")]
        public IActionResult GetByStadium(string estadio)
        {
            List<Jogo> jogosBuscado = _jogoRepository.ListarPorEstadio(estadio);

            if (jogosBuscado.Count == 0)
            {
                return NotFound("Nenhum jogo encontrado para o estádio buscado");
            }

            return Ok(jogosBuscado);
        }

        /// <summary>
        /// Busca todos os jogos por seleção
        /// </summary>
        /// <param name="selecao"> Nome da seleção dos confrontos a ser buscado </param>
        /// <returns> Uma lista de jogos e um status code 200 - Ok </returns>
        [HttpGet("BuscarPorSelecao/{selecao}")]
        public IActionResult GetByTeam(string selecao)
        {
            List<Jogo> jogosBuscado = _jogoRepository.ListarPorSelecao(selecao);

            if (jogosBuscado.Count == 0)
            {
                return NotFound("Nenhum jogo encontrado para a seleção buscada");
            }

            return Ok(jogosBuscado);
        }

        /// <summary>
        /// Busca todas as datas dos jogos
        /// </summary>
        /// <returns> Uma lista de datas de jogos e um status code 200 - Ok </returns>
        [HttpGet("Datas")]
        public IActionResult listarDatas()
        {
            return Ok(_jogoRepository.ListaDeDatas());
        }
    }
}
