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
    }
}
