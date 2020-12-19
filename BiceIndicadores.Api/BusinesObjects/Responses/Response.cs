using System;
using System.Collections.Generic;
using System.Text;

namespace Bice.BusinessObjects
{
    public class Response<T>
    {
        public string CodigoError { get; set; }
        public string MensajeHumano { get; set; }
        public string MensajeSistema { get; set; }
        public List<T> Contenido { get; set; }
    }
}
