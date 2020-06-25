using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

            if (dados == null)
            {
                return NotFound("E-mail/Apelido ou senha inválidos");
            }
            else
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, dados.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, dados.Apelido),
                new Claim(JwtRegisteredClaimNames.Jti, dados.Id.ToString()),
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WSTower-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "WSTower.API",                // emissor do token
                    audience: "WSTower.API",              // destinatário do token
                    claims: claims,                          // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                    signingCredentials: creds                // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }
    }
}
