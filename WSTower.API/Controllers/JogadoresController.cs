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

        /// <summary>
        /// Lista de jogadores
        /// </summary>
        /// <returns>Retorna uma lista de jogadores</returns>
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

        /// <summary>
        /// Lista de jogadores ordenadas
        /// </summary>
        /// <returns>Retorna uma lista de jogadores ordenadas por posição e nº de camisa</returns>
        [HttpGet("Ordem")]
        public IActionResult ListarJogadoresPorOrdem()
        {
            return Ok(_jogadorRepository.ListarJogadoresOrdenados());
        }

        /// <summary>
        /// Lista de jogadores ordenados
        /// </summary>
        /// <param name="id">Id da seleção que será buscado</param>
        /// <returns>Retorna uma lista de jogadores por seleção</returns>
        [HttpGet("Selecao/{id}")]
        public IActionResult ListarJogadoresPorSelecao(int id)
        {
            return Ok(_jogadorRepository.ListarJogadoresporSelecao(id));
        }

        /// <summary>
        /// Lista de jogadores ordenados
        /// </summary>
        /// <returns>Retorna uma lista de jogadores ordenados por nome</returns>
        [HttpGet("Nome/{nome}")]
        public IActionResult ListarJogadoresPorNome(string nome)
        {
            return Ok(_jogadorRepository.ListarJogadoresPorNome(nome));
        }
    }
}
