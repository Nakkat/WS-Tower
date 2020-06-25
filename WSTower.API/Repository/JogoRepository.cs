using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Contexts;
using WSTower.API.Domains;
using WSTower.API.Interface;

namespace WSTower.API.Repository
{
    public class JogoRepository : IJogoRepository
    {
        WSTowerContext _context = new WSTowerContext();

        public List<Jogo> ListarJogos()
        {
             return _context.Jogo.Include(sc => sc.SelecaoCasaNavigation).Include(sv => sv.SelecaoVisitanteNavigation).ToList();
        }

        public List<Jogo> ListarPorOrdemDeData()
        {
            return _context.Jogo.OrderBy(j => j.Data).ToList();
        }

        public List<Jogo> ListarPorData(DateTime data)
        {
            return _context.Jogo.ToList().FindAll(j => j.Data == data);
        }

        public List<Jogo> ListarPorEstadio(string estadio)
        {
            return _context.Jogo.ToList().FindAll(j => j.Estadio == estadio);
        }

        public List<Jogo> ListarPorSelecao(string selecao)
        {
            return _context.Jogo.ToList().FindAll(j => j.SelecaoCasaNavigation.Nome == selecao
                                            || j.SelecaoVisitanteNavigation.Nome == selecao);
        }

        public List<DateTime> ListaDeDatas()
        {
            List<DateTime> datas = new List<DateTime>();

            for (int i = 0; i < ListarJogos().Count; i++)
            {
                Jogo jogo = new Jogo();
                DateTime data = jogo.Data.Value;
                datas.Add(data);
            }

            return datas;
        }
    }
}
