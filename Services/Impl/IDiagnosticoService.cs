using MetaenlaceCitaClinica.Models.DTOs.ResponseDTO;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Services.Impl
{
    public interface IDiagnosticoService
    {
        Task<DiagnosticoDTO> ObtenerDiagnosticoPorId(int idDiagnostico);
        Task<IEnumerable<DiagnosticoDTO>> ObtenerTodosDiagnostico();
        Task<DiagnosticoDTO> CrearDiagnostico(DiagnosticoDTO diagnostico);
        Task ActualizarDiagnostico(int idDiagnostico, DiagnosticoDTO diagnostico);
        Task EliminarDiagnostico(int idDiagnostico);
    }
}
