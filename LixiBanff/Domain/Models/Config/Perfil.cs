using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class Perfil
    {
        // Primary Key
        public int PerfilId { get; set; }

        // Properties
        public string NombrePerfil { get; set; }
        public int OrdenPerfil { get; set; }

        // Default System Values
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
