using System.Text.Json.Serialization;

namespace MetaenlaceCitaClinica.Models.DTOs.ResponseDTO
{
    public class CitaDTO
    {
        [JsonIgnore]
        public int CitaID { get; set; }
        public DateTime? FechaHora { get; set; }
        public string? MotivoCita { get; set; }
        public int? Attribute11 { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public int DiagnosticoID { get; set; }
    }
}
