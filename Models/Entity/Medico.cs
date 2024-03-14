using System.ComponentModel.DataAnnotations;

namespace MetaenlaceCitaClinica.Models.Entity
{
    public class Medico : Usuario
    {
        public string? NumColegiado { get; set; }

        // Atributos
        public virtual ICollection<Cita> Citas { get; set; }
        public virtual ICollection<MedicoPaciente> Pacientes { get; set; }
    }
}
