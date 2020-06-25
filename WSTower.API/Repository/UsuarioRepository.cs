using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Contexts;
using WSTower.API.Domains;
using WSTower.API.Interface;
using WSTower.API.ViewModel;

namespace WSTower.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WSTowerContext _context = new WSTowerContext();

        public bool Cadastro(Usuario NovoUsuario)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Apelido == NovoUsuario.Apelido || u.Email == NovoUsuario.Email);
            if (usuario == null)
            {
                _context.Usuario.Add(NovoUsuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public Usuario Login(LoginViewModel login)
        {
            Usuario usuarioBuscado = _context.Usuario.FirstOrDefault(u => u.Email == login.Usuario && u.Senha == login.Senha || u.Apelido == login.Usuario && u.Senha == login.Senha);

            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }
    }
}
