using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Domains;

namespace WSTower.API.Interface
{
    interface IJogoRepository
    {
        public List<Jogo> ListarJogos();
    }
}
