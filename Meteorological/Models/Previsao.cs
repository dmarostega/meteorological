using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meteorological.Models
{
    public class Previsao
    {
        public DateTime Dia { get; set; }
        public string Tempo { get; set; }
        public int Maxima { get; set; }
        public int Minima { get; set; }
        public double Iuv { get; set; }

        public Previsao() { }
    }
}
