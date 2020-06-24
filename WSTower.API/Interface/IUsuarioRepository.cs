using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Domains;
using WSTower.API.ViewModel;

namespace WSTower.API.Interface
{
    interface IUsuarioRepository
    {
        public Usuario Login(LoginViewModel login);

        public bool Cadastro(Usuario NovoUsuario);

        public List<Usuario> ListarUsuarios();
    }
}
