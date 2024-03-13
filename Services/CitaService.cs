using AutoMapper;
using MetaenlaceCitaClinica.Models.DTOs.ResponseDTO;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository;
using MetaenlaceCitaClinica.Services.Impl;

namespace MetaenlaceCitaClinica.Services
{
    public class CitaService : ICitaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CitaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Serv.        Actualizar Cita
        public async Task ActualizarCita(int idCita, CitaDTO cita)
        {
            var citaExistente = await _unitOfWork.Citas.ObtenerIdCita(idCita) ?? throw new ArgumentException("La cita no existe");
            // Actualizar las propiedades del usuario existente con los nuevos valores
            citaExistente.CitaID = cita.CitaID;
            citaExistente.MotivoCita = cita.MotivoCita;
            citaExistente.Attribute11 = cita.Attribute11;
            citaExistente.PacienteID = cita.PacienteID;
            citaExistente.MedicoID = cita.MedicoID;
            await _unitOfWork.SaveChangesAsync();
        }

        // Serv.        Crear Crear
        public async Task<CitaDTO> CrearCita(CitaDTO cita)
        {
            var nuevoCita = _mapper.Map<Cita>(cita);
            await _unitOfWork.Citas.CrearCita(nuevoCita);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CitaDTO>(nuevoCita);
        }

        // Serv.        Eliminar Cita
        public async Task EliminarCita(int idCita)
        {
            var cita = await _unitOfWork.Citas.ObtenerIdCita(idCita) ?? throw new ArgumentException("La cita no existe");
            await _unitOfWork.Citas.EliminarCita(cita);
            await _unitOfWork.SaveChangesAsync();
        }

        // Serv.        Obtener Cita
        public async Task<CitaDTO> ObtenerCitaPorId(int idCita)
        {
            var cita = await _unitOfWork.Citas.ObtenerIdCita(idCita);
            var citaDTO = _mapper.Map<CitaDTO>(cita);
            return citaDTO;
        }

        // Serv.        Listar Citas
        public async Task<IEnumerable<CitaDTO>> ObtenerTodosCitas()
        {
            var citas = await _unitOfWork.Citas.ObtenerCitas();
            var citaDTO = _mapper.Map<IEnumerable<Cita>, IEnumerable<CitaDTO>>(citas);
            return citaDTO;
        }
    }
}
