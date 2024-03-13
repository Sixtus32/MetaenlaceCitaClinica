using System.Text.Json.Serialization;

namespace MetaenlaceCitaClinica.Models.DTOs
{
    public class UsuarioDTO
    {
        [JsonIgnore]
        public int UsuarioID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? UsuarioNom { get; set; }
        public string? Clave { get; set; }
    }
}
