using Bice.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bice.DataAccess.Infrastructure
{
    public interface IIndicadorRepository
    {
        Task<Response<Indicador_Entity>> GetIndicadores(FiltroIndicador param);
    }
}
