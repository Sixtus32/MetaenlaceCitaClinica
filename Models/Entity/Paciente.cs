using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetaenlaceCitaClinica.Models.Entity
{
    public class Paciente : Usuario
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Nº SEG. SOCIAL")]
        public string? NSS { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "NUMERO DE TARJETA")]
        public string? NumTarjeta { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "TELÉFONO")]
        public string? Telefono { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "DIRECCIÓN")]
        public string? Direccion { get; set; }

        // Atributos
        public virtual ICollection<Cita> Citas { get; set; }
        public virtual ICollection<MedicoPaciente> Medicos { get;  set; }
    }
}
