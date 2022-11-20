using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LixiBanff.Domain.Models
{
    public class Sensor
    {
        // Primary Key
        public int SensorId { get; set; }

        // Properties
        public int PosicionSensor { get; set; }
        public string CodigoSensor { get; set; }
        public string NombreSensor { get; set; }
        public string Mac { get; set; }

        // FK       
        public int? NodoId { get; set; }
        public Nodo Nodo { get; set; }

        // Default System Values         
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
