using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Repository.Impl
{
    public interface IDiagnosticoRepository
    {
        Task<Diagnostico> ObtenerIdDiagnostico(int id);
        Task<IEnumerable<Diagnostico>> ObtenerDiagnosticos();
        Task<Diagnostico> CrearDiagnostico(Diagnostico diagnostico);
        Task ActualizarDiagnostico(Diagnostico diagnostico);
        Task EliminarDiagnostico(Diagnostico diagnostico);
    }
}
