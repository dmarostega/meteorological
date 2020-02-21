using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Meteorological.Models
{
    public class PrevisaoViewModel
    {
        public int Code { get; set; }
        public Cidade Cidade { get; set; }
    }
}
