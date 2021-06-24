using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    [Table("candidato")]
    public class Candidato
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int edad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MinLength(13, ErrorMessage = "Mínimo 13 caracteres"), MaxLength(13, ErrorMessage = "Máximo 13 caracteres")]
        public string cedula { get; set; }

    }
}
