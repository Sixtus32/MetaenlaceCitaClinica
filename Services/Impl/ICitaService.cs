using MetaenlaceCitaClinica.Models.DTOs.ResponseDTO;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Services.Impl
{
    public interface ICitaService
    {
        Task<CitaDTO> ObtenerCitaPorId(int idCita);
        Task<IEnumerable<CitaDTO>> ObtenerTodosCitas();
        Task<CitaDTO> CrearCita(CitaDTO cita);
        Task ActualizarCita(int idCita, CitaDTO cita);
        Task EliminarCita(int idCita);
    }
}
