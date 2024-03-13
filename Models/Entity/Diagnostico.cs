using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetaenlaceCitaClinica.Models.Entity
{
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagnosticoID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "VALORACIÓN ESPECIALISTA")]
        public string? ValoracionEspecialista { get; set; }

        [StringLength(255)]
        [Display(Name = "ENFERMEDAD")]
        public string? Enfermedad { get; set; }

        // la cita del diagnóstico
        public int CitaID { get; set; }
        [ForeignKey("CitaID")]
        public virtual Cita? Cita { get; set; }
    }
}
