using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bice.BusinessActions;
using Bice.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bice.Indicadores.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class IndicadorController : ControllerBase
    {
        private readonly IndicadorActions _context;

        public IndicadorController(IndicadorActions context)
        {
            _context = context;
        }

        // GET api
        [HttpPost]
        [Route("GetItems")]
        public async Task<Response<Indicador_Entity>> Get([FromBody] FiltroIndicador param)
        {
            return await _context.GetIndicadores(param);
        }

    }
}
