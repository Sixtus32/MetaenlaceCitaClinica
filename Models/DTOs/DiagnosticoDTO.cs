using System.Text.Json.Serialization;

namespace MetaenlaceCitaClinica.Models.DTOs
{
    public class DiagnosticoDTO
    {
        //[JsonIgnore]
        public int DiagnosticoID { get; set; }
        public string? ValoracionEspecialista { get; set; }
        public string? Enfermedad { get; set; }
        public int CitaID { get; set; }
    }
}
