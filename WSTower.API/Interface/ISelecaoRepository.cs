﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Domains;

namespace WSTower.API.Interface
{
    interface ISelecaoRepository
    {
        public List<Selecao> ListarSelecao();
    }
}
