﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.API.Contexts;
using WSTower.API.Interface;

namespace WSTower.API.Repository
{
    public class SelecaoRepository : ISelecaoRepository
    {
        WSTowerContext _context = new WSTowerContext();
    }
}
