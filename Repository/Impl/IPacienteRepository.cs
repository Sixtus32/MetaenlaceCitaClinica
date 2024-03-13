using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Repository.Impl
{
    public interface IPacienteRepository
    {
        Task<Paciente> ObtenerId(int id);                   // [Repo.   Obtener Paciente Entity]
        Task<IEnumerable<Paciente>> ObtenerTodos();         // [Repo.   Listar Paciente Entity]
        Task<Paciente> CrearPaciente(Paciente paciente);    // [Repo.   Crear Paciente Entity]
        Task ActualizarPaciente(Paciente paciente);         // [Repo.   Actualizar Paciente Entity]
        Task EliminarPaciente(Paciente paciente);           // [Repo.   Eliminar Paciente Entity]
    }
}
