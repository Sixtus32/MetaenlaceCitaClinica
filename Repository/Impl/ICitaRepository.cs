using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Repository.Impl
{
    public interface ICitaRepository
    {
        Task<Cita> ObtenerIdCita(int id);
        Task<IEnumerable<Cita>> ObtenerCitas();
        Task<Cita> CrearCita(Cita cita);
        Task ActualizarCita(Cita cita);
        Task EliminarCita(Cita cita);
    }
}
