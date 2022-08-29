using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class Pila
    {
        // Primary Key
        public int PilaId { get; set; }

        // Properties
        public int PosicionPila { get; set; }    
        public string CodigoPila { get; set; }
        public string NombrePila { get; set; }
        public int CantidadPanos { get; set; }
        public double AnchoPila { get; set; }
        public double LargoPila { get; set; }
        public string DescripcionPila { get; set; }
        public string UbicacionPila { get; set; }
        public string LatLongPila { get; set; }

        // Lists
        public List<Pano> Pano { get; set; }

        // Default System Values       
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
