using System.Text.Json.Serialization;

namespace MetaenlaceCitaClinica.Models.DTOs
{
    public class MedicoDTO : UsuarioDTO
    {
        [JsonIgnore]
        public int MedicoID { get; set; }
        public string? NumColegiado { get; set; }
        public ICollection<CitaDTO>? Citas { get; set; } = new List<CitaDTO>();
    }
}
