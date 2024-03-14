using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Services.Impl
{
    public interface ICitaService
    {
        Task<CitaDTO> ObtenerCitaPorId(int idCita);
        Task<IEnumerable<CitaDTO>> ObtenerTodosCitas();
        Task<CitaDTO> CrearCita(CitaRequestDTO cita);
        Task ActualizarCita(int idCita, CitaRequestDTO cita);
        Task EliminarCita(int idCita);
    }
}
