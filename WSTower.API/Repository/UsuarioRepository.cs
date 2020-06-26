using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuario.FirstOrDefault(u => u.Id == id);
        }

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

        public void Editar(UsuarioViewModel NovosDados)
        {
            Usuario DadosAntigos = BuscarPorId(NovosDados.Id);
            if (NovosDados.Nome != null)
            {
                DadosAntigos.Nome = NovosDados.Nome;
            }
            if (NovosDados.Senha != null)
            {
                DadosAntigos.Senha = NovosDados.Senha;
            }
            if (NovosDados.Apelido != null)
            {
                DadosAntigos.Apelido = NovosDados.Apelido;
            }
            if (NovosDados.Foto != null)
            {
                DadosAntigos.Foto = NovosDados.Foto;
            }
            if (NovosDados.Email != null)
            {
                DadosAntigos.Email = NovosDados.Email;
            }
            _context.Update(DadosAntigos);
            _context.SaveChanges();
        }

        public List<Usuario> ListarUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public Usuario Login(LoginViewModel loginViewModel)
        {
             return _context.Usuario.FirstOrDefault(u =>  u.Email == loginViewModel.Usuario && u.Senha == loginViewModel.Senha || u.Apelido == loginViewModel.Usuario && u.Senha == loginViewModel.Senha);
        }
    }
}
