using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.API.Domains;
using WSTower.API.Interface;
using WSTower.API.Repository;

namespace WSTower.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        /// <summary>
        /// Busca um usuário referente ao id informado na url
        /// </summary>
        /// <param name="id"></param>
        /// <returns>o usuário encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Edita um usuário já existente
        /// </summary>
        /// <param name="novosDados">novos dados do usuário</param>
        /// <param name="id">Id do usuário a ser editado</param>
        /// <returns>statuscode 204, que informa que a solicitação foi bem sucedida</returns>
        [HttpPut("{id}")]
        public IActionResult Editar(int id, Usuario novosDados)
        {
            try
            {
                novosDados.Id = id;
                _usuarioRepository.Editar(novosDados);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.ListarUsuarios());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">dados do novo usuário</param>
        /// <returns>que o usuário foi criado com sucesso</returns>
        [HttpPost]
        public IActionResult Cadastro(Usuario novoUsuario)
        {
            try
            {
                // se retornar true significa que o usuario foi cadastrado com sucesso
                if (_usuarioRepository.Cadastro(novoUsuario))
                {
                    return StatusCode(201);
                }
                return BadRequest("Usuário já existe");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }
    }
}
