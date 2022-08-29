using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class TipoNodo
    {
        // Primary Key
        public int TipoNodoId { get; set; }

        // Properties    
        public string NombreTipoNodo { get; set; }       

        // Default System Values
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
