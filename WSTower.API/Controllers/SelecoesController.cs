using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.API.Interface;
using WSTower.API.Repository;

namespace WSTower.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SelecoesController : ControllerBase
    {
        private ISelecaoRepository _selecaoRepository { get; set; }

        public SelecoesController()
        {
            _selecaoRepository = new SelecaoRepository();
        }
    }
}
