using System;
using System.Collections.Generic;
using System.Text;

namespace Bice.BusinessObjects
{
      public class Indicador_Entity
    {
        public List<Indicador> Indicadores { get; set; }

    }

    public class Indicador
    {
        public string key { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public string date { get; set; }
        public double value { get; set; }

    }
}
