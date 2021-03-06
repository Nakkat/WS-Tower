﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Domains;

namespace WSTower.API.Interface
{
    interface IJogoRepository
    {
        public List<Jogo> ListarJogos();

        public List<Jogo> ListarPorData(DateTime data);

        public List<Jogo> ListarPorEstadio(string estadio);

        public Selecao ListarPorSelecao(string selecao);

        public List<DateTime> ListaDeDatas();
    }
}
