using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class Nodo
    {
        // Primary Key
        public int NodoId { get; set; }

        // Properties
        public int PosicionNodo { get; set; }
        public string CodigoNodo { get; set; }
        public string NombreNodo { get; set; }
        public string Mac { get; set; }

        // FK       
        public int? PanoId { get; set; }
        public Pano Pano { get; set; }       
        public int TipoNodoId { get; set; }
        public TipoNodo TipoNodo { get; set; }

        // Default System Values         
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
