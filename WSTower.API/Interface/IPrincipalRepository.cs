using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Domains;

namespace WSTower.API.Interface
{
    interface IPrincipalRepository
    {
        public List<Jogo> Listar();

        public List<Jogo> ListarPorData(DateTime data);

        public List<Jogo> ListarPorEstadio(string estadio);

        public List<Jogo> ListarPorSelecao(string selecao);

        public List<DateTime> ListaDeDatas();
    }
}
