using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel Dadoslogin)
        {
           Usuario dados = _usuarioRepository.Login(Dadoslogin);
            //corrigir caso for usar token
            if (dados == null)
            {
                return BadRequest();
            }
            else
            {
                return StatusCode(200);
                
            }
        }
    }
}
