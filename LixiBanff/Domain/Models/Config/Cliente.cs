using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class Cliente
    {
        // Primary Key
        public int ClienteId { get; set; }

        // Properties
        [Required]
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }       
        public string DescripcionCliente { get; set; }

        // Default System Values 
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
