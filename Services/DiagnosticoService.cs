using AutoMapper;
using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository;
using MetaenlaceCitaClinica.Services.Impl;

namespace MetaenlaceCitaClinica.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosticoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Serv.        Actualizar Diagnostico
        public async Task ActualizarDiagnostico(int idDiagnostico, DiagnosticoDTO diagnostico)
        {
            var diagnosticoExistente = await _unitOfWork.Diagnosticos.ObtenerIdDiagnostico(idDiagnostico) ?? throw new ArgumentException("El diagnóstico no existe");

            // Actualizar las propiedades del diagnóstico
            diagnosticoExistente.ValoracionEspecialista = diagnostico.ValoracionEspecialista;
            diagnosticoExistente.Enfermedad = diagnostico.Enfermedad;

            // Guardar los cambios en la base de datos
            await _unitOfWork.SaveChangesAsync();
        }

        // Serv.        Crear Diagnostico
        public async Task<DiagnosticoDTO> CrearDiagnostico(DiagnosticoDTO diagnostico)
        {
            var nuevoDiagnostico = _mapper.Map<Diagnostico>(diagnostico);
            await _unitOfWork.Diagnosticos.CrearDiagnostico(nuevoDiagnostico);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DiagnosticoDTO>(nuevoDiagnostico);
        }

        // Serv.        Eliminar Diagnostico
        public async Task EliminarDiagnostico(int idDiagnostico)
        {
            var diagnostico = await _unitOfWork.Diagnosticos.ObtenerIdDiagnostico(idDiagnostico) ?? throw new ArgumentException("La cita no existe");
            await _unitOfWork.Diagnosticos.EliminarDiagnostico(diagnostico);
            await _unitOfWork.SaveChangesAsync();
        }

        // Serv.        Obtener Diagnostico por id
        public async Task<DiagnosticoDTO> ObtenerDiagnosticoPorId(int idDiagnostico)
        {
            var diagnostico = await _unitOfWork.Diagnosticos.ObtenerIdDiagnostico(idDiagnostico);
            var diagnosticoDTO = _mapper.Map<DiagnosticoDTO>(diagnostico);
            return diagnosticoDTO;
        }

        // Serv.        Listar Diagnostico
        public async Task<IEnumerable<DiagnosticoDTO>> ObtenerTodosDiagnostico()
        {
            var diagnosticos = await _unitOfWork.Diagnosticos.ObtenerDiagnosticos();
            var diagnosticosDTO = _mapper.Map<IEnumerable<Diagnostico>, IEnumerable<DiagnosticoDTO>>(diagnosticos);
            return diagnosticosDTO;
        }
    }
}
