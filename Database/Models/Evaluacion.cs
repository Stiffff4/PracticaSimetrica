using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    [Table("evaluacion")]
    public class Evaluacion
    {
        [Key]
        [Required]
        public int id { get; set; }

        [ForeignKey("id_candidato")]
        public int id_candidato { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime fecha_evaluacion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int resultado_examen_psicologico { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int resultado_examen_algoritmos { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int resultado_examen_sql { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int resultado_final { get; set; }

    }
}
