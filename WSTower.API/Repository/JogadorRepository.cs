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
    public class JogadorRepository : IJogadorRepository
    {
        WSTowerContext _context = new WSTowerContext();
        public List<Jogador> ListarJogadores()
        {
            return _context.Jogador.ToList();
        }

        public List<Jogador> ListarJogadoresOrdenados()
        {
            return _context.Jogador.OrderBy(j => j.NumeroCamisa).OrderBy(j => j.Posicao).ToList();
        }
    }
}
