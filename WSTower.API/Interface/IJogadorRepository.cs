using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Domains;

namespace WSTower.API.Interface
{
    interface IJogadorRepository
    {
        public List<Jogador> ListarJogadores();

        public List<Jogador> ListarJogadoresOrdenados();

        public Selecao ListarJogadoresporSelecao(int IdSelecao);
    }
}
