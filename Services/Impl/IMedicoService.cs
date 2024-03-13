using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Models.DTOs.ResponseDTO;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Services.Impl
{
    public interface IMedicoService
    {
        Task<MedicoDTO> ObtenerMedicoPorId(int idMedico);
        Task<IEnumerable<MedicoDTO>> ObtenerTodosMedicos();
        Task<MedicoDTO> CrearMedico(MedicoRequestDTO medico);
        Task ActualizarMedico(int idMedico, MedicoRequestDTO medico);
        Task EliminarMedico(int idMedico);
    }
}
