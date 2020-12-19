using Bice.BusinessObjects;
using Bice.Context;
using Bice.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bice.DataAccess.DataService
{
    public class IndicadorRepository : IIndicadorRepository
    {

        private readonly ExternalApiContext apiContext = new ExternalApiContext();

        public IndicadorRepository(ExternalApiContext dbContext)
        {
            apiContext = dbContext;
        }

        public async Task<Response<Indicador_Entity>> GetIndicadores(FiltroIndicador param)
        {
            Response<Indicador_Entity> entidad = new Response<Indicador_Entity>();
            
            entidad.Contenido = new List<Indicador_Entity>();

            try
            {
                Indicador_Entity resul = await Task.Run(() => apiContext.Indicadores);

                if (!string.IsNullOrEmpty(param.TipoIndicador) && resul.Indicadores.Count > 0)
                    resul.Indicadores = resul.Indicadores.Where(x => x.key == param.TipoIndicador).ToList();

                entidad.Contenido.Add(resul);

            }
            catch(Exception err)
            {
                entidad.CodigoError = "E01";
                if (err.InnerException != null)
                    entidad.MensajeSistema = err.InnerException.Message;
                else
                    entidad.MensajeSistema = err.Message;
                entidad.MensajeHumano = "Hubo un inconveniente al recuperar los registros.";
                entidad.Contenido = null;
            }

            return entidad;

        }
    }
}
