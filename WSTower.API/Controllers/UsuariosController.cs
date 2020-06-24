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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario novoUsuario)
        {
            // se retornar true significa que o usuario foi cadastrado com sucesso
            if (_usuarioRepository.Cadastro(novoUsuario))
            {
                return StatusCode(201);
            }
            return BadRequest();
        }
    }
}
