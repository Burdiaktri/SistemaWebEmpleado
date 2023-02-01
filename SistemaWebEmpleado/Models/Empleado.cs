using SistemaWebEmpleado.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string DNI { get; set; }

        [RegularExpression("[A-Z]{1}[0-9]{5}")]
        [Required]
        public string Legajo { get; set; }

        [CheckValidYearAttribute]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Titulo { get; set; }


    }
}
