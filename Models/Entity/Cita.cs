using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetaenlaceCitaClinica.Models.Entity
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CitaID { get; set; }

        // Otras atributos de la cita
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FECHA Y HORA")]
        public DateTime? FechaHora { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "MOTIVO DE LA CITA")]
        public string? MotivoCita { get; set; }

        
        [Display(Name = "Nº COLEGIADO")]
        public int? Attribute11 { get; set; }

        // Relaciones con otras entidades
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }

        // Propiedades de navegación
        public virtual Paciente? Paciente { get; set; }
        public virtual Medico? Medico { get; set; }

        // Relación uno a uno con Diagnostico
        public virtual Diagnostico? Diagnostico { get; set; } // relación uno a uno
    }
}
