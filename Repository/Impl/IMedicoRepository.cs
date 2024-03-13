using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Repository.Impl
{
    public interface IMedicoRepository
    {
        Task<Medico> ObtenerIdMedico(int id);
        Task<IEnumerable<Medico>> ObtenerMedicos();
        Task<Medico> CrearMedico(Medico medico);
        Task ActualizarMedico(Medico medico);
        Task EliminarMedico(Medico medico);
    }
}
