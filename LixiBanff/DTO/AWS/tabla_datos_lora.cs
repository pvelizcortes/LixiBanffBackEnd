using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LixiBanff.DTO
{
    public class tabla_datos_lora
    {
        public string Time { get; set; }
        public string devEui { get; set; }
        public datos_decodificados datos_decodificados { get; set; }   
    }
}
