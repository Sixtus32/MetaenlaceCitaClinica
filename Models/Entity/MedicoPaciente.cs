using System.ComponentModel.DataAnnotations;

namespace MetaenlaceCitaClinica.Models.Entity
{
    public class MedicoPaciente
    {
        public int MedicoID { get; set; }
        public int PacienteID { get; set; }
        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
