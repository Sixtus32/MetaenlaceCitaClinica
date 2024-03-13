using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MetaenlaceCitaClinica.Models.DTOs.ResponseDTO
{
    public class PacienteDTO : UsuarioDTO
    {
        [JsonIgnore]
        public int PacienteID { get; set; }

        public string? NSS { get; set; }

        public string? NumTarjeta { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public ICollection<CitaDTO> Citas { get; set; } = new List<CitaDTO>();
        // public ICollection<MedicoDTO> Medico { get; set; }
    }
}
