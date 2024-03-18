using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Services.Impl
{
    public interface IDiagnosticoService
    {
        Task<DiagnosticoDTO> ObtenerDiagnosticoPorId(int idDiagnostico);
        Task<IEnumerable<DiagnosticoDTO>> ObtenerTodosDiagnostico();
        Task<DiagnosticoDTO> CrearDiagnostico(DiagnosticoRequestDTO diagnostico);
        Task ActualizarDiagnostico(int idDiagnostico, DiagnosticoRequestDTO diagnostico);
        Task EliminarDiagnostico(int idDiagnostico);
    }
}
