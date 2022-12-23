using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LixiBanff.DTO
{
    public class datos_decodificados
    {
        public string Time { get; set; }
        public string devEui { get; set; }
        public double fPort { get; set; }
        public double freq { get; set; }
        public double nnodo { get; set; }
        public string sensor { get; set; }
        public double value { get; set; }       
    }
}
