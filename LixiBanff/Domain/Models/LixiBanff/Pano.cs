using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class Pano
    {
        // Primary Key
        public int PanoId { get; set; }

        // Properties
        public int PosicionPano { get; set; }
        public string CodigoPano { get; set; }
        public string NombrePano { get; set; }
        public double AnchoPano { get; set; }
        public double LargoPano { get; set; }
        public string DescripcionPano { get; set; }

        // FK       
        public int? PilaId { get; set; }
        public Pila Pila { get; set; }

        // Lists
        public List<Nodo> Nodo { get; set; }


        // Default System Values        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
