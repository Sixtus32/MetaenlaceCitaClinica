using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Models.DTOs.ResponseDTO;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Services.Impl
{
    public interface IPacienteService
    {
        Task<PacienteDTO> ObtenerPacientePorId(int idPaciente);                     // [Serv.   Obtener Paciente Por id]
        Task<IEnumerable<PacienteDTO>> ObtenerTodosPacientes();                     // [Serv.   Listar Pacientes]
        Task<PacienteDTO> CrearPaciente(PacienteRequestDTO paciente);               // [Serv.   Crear Paciente]
        Task ActualizarPaciente(int idPaciente, PacienteRequestDTO paciente);       // [Serv.   Actualizar Paciente]
        Task EliminarPaciente(int idPaciente);                                      // [Serv.   Eliminar Paciente]
    }
}
