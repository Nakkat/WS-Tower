using Microsoft.AspNetCore.Mvc.Formatters;
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

        public List<DateTime> ListaDeDatas()
        {
            List<DateTime> datas = new List<DateTime>();
            List<Jogo> jogos = ListarJogos();
            foreach (var jogo in jogos)
            {
                datas.Add(Convert.ToDateTime(jogo.Data).Date); 
            }
            return datas.Distinct().ToList();
        }

        public List<Jogo> ListarJogos()
        {
             return _context.Jogo.OrderBy(j => j.Data).Include(sc => sc.SelecaoCasaNavigation).Include(sv => sv.SelecaoVisitanteNavigation).ToList();
        }
        public List<Jogo> ListarPorData(DateTime data)
        {
            return _context.Jogo.ToList().FindAll(j => Convert.ToDateTime(j.Data).Date == data);
        }

        public List<Jogo> ListarPorEstadio(string estadio)
        {
            return _context.Jogo.ToList().FindAll(j => j.Estadio == estadio);
        }

        public List<Jogo> ListarPorSelecao(string selecao)
        {
            return _context.Jogo.ToList().FindAll(j => j.SelecaoCasaNavigation.Nome == selecao || j.SelecaoVisitanteNavigation.Nome == selecao);
        }
    }
}
