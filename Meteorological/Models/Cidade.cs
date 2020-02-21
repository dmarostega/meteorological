using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meteorological.Models
{
    public class Cidade
    {
        public string Nome { get; set; }
        public string UF { get; set; }
        public DateTime Atualizacao { get; set; }
        public List<Previsao> Previsoes = new List<Previsao>(); 

        public Cidade() { }

    }
}
