using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSTower.API.Domains;
using WSTower.API.Interface;
using WSTower.API.Repository;
using WSTower.API.ViewModel;

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
        [HttpGet("BuscarPorEstadio")]
        public IActionResult GetByStadium(StringViewModel estadio)
        {
            List<Jogo> jogosBuscado = _jogoRepository.ListarPorEstadio(estadio.Nome);

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
        [HttpGet("BuscarPorSelecao")]
        public IActionResult GetByTeam(StringViewModel selecao)
        {
            // retorna uma seleção e desta seleção é retirada uma lista de jogos
            Selecao jogosBuscado = _jogoRepository.ListarPorSelecao(selecao.Nome);

            if (jogosBuscado.JogoSelecaoCasaNavigation != null || jogosBuscado.JogoSelecaoVisitanteNavigation != null)
            {
                return Ok(jogosBuscado);
                
            }
            return NotFound("Nenhum jogo encontrado para a seleção buscada");
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
