using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class Usuario
    {
        // Primary Key
        public int UsuarioId { get; set; }

        // Properties
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string CorreoUsuario { get; set; }
        public string TelefonoUsuario { get; set; }      
        public string DescripcionUsuario { get; set; }

        // FK 
        [Required]
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }

        // Default System Values
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
