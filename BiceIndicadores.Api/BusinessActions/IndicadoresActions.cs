using System;
using System.Collections.Generic;
using System.Text;
using Bice.DataAccess.Infrastructure;
using Bice.BusinessObjects;
using System.Threading.Tasks;

namespace Bice.BusinessActions
{
    public class IndicadorActions
    {
        private readonly IIndicadorRepository _context;

        public IndicadorActions(IIndicadorRepository context)
        {
            _context = context;
        }

        public async Task<Response<Indicador_Entity>> GetIndicadores(FiltroIndicador param)
        {
            //El parámetro "param" navega desde la capa Api
            //Se puede utilizar para aplicar las reglas de negocio necesarias para el proceso

            Response<Indicador_Entity> result = new Response<Indicador_Entity>();
            
            try
            {

                    result = await _context.GetIndicadores(param);

                    result.CodigoError = "E00";
                    result.MensajeHumano = "Consulta exitosa!";
                    result.MensajeSistema = "Record(s) found";

                return result;

            }catch(Exception err)
            {
                result.Contenido = new List<Indicador_Entity>();
                result.CodigoError = "E01";
                result.MensajeSistema = "Error en la consulta: " + err.InnerException.Message;
                result.MensajeHumano = "Error en la consulta!";
                return result;
            }

        }

    }
}
