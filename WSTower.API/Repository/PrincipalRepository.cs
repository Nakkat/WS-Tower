using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Contexts;
using WSTower.API.Domains;
using WSTower.API.Interface;

namespace WSTower.API.Repository
{
    public class PrincipalRepository : IPrincipalRepository
    {
        WSTowerContext ctx = new WSTowerContext();

        public List<Jogo> Listar()
        {
            return ctx.Jogo.OrderBy(j => j.Data).ToList();
        }

        public List<Jogo> ListarPorData(DateTime data)
        {
            return ctx.Jogo.ToList().FindAll(j => j.Data == data);
        }

        public List<Jogo> ListarPorEstadio(string estadio)
        {
            return ctx.Jogo.ToList().FindAll(j => j.Estadio == estadio);
        }

        public List<Jogo> ListarPorSelecao(string selecao)
        {
            return ctx.Jogo.ToList().FindAll(j => j.SelecaoCasaNavigation.Nome == selecao
                                            || j.SelecaoVisitanteNavigation.Nome == selecao);
        }

        public List<DateTime> ListaDeDatas()
        {
            List<Jogo> listaJogos = Listar();
            List<DateTime> datas = new List<DateTime>();

            for (int i = 0; i < listaJogos.Count; i++)
            {
                Jogo jogo = new Jogo();
                DateTime data = jogo.Data.Value;
                datas.Add(data);
            }

            return datas;
        }
    }
}
