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

        public List<Jogador> ListarJogadoresPorNome(string nome)
        {
            return _context.Jogador.ToList().FindAll(j => j.Nome == nome);
        }

        public Selecao ListarJogadoresporSelecao(int IdSelecao)
        {
            return _context.Selecao.Select(s => new Selecao()
            {
                Id = s.Id,
                Jogador  = s.Jogador
            }).Include(s => s.Jogador).FirstOrDefault(s => s.Id == IdSelecao);
        }
    }
}

        
    
        
   

