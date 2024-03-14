using AutoMapper;
using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
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
        public async Task ActualizarCita(int idCita, CitaRequestDTO cita)
        {
            var citaExistente = await _unitOfWork.Citas.ObtenerIdCita(idCita) ?? throw new ArgumentException("La cita no existe");
            // Actualizar las propiedades del usuario existente con los nuevos valores
            citaExistente.FechaHora = cita.FechaHora;
            citaExistente.MotivoCita = cita.MotivoCita;
            citaExistente.Attribute11 = cita.Attribute11;
            citaExistente.PacienteID = cita.PacienteID;
            citaExistente.MedicoID = cita.MedicoID;
            await _unitOfWork.SaveChangesAsync();
        }

        // Serv.        Crear Crear
        public async Task<CitaDTO> CrearCita(CitaRequestDTO cita)
        {
            try
            {
                // Verifica si el paciente existe antes de crear la cita
                var pacienteExistente = await _unitOfWork.Pacientes.ObtenerId(cita.PacienteID);
                if (pacienteExistente == null)
                {
                    throw new Exception($"No se encontró un paciente con el ID {cita.PacienteID}.");
                }

                // Mapea la solicitud de cita a una entidad Cita
                var nuevaCita = _mapper.Map<Cita>(cita);

                // Asigna el paciente a la cita
                nuevaCita.Paciente = pacienteExistente;

                // Crea la cita en la base de datos
                await _unitOfWork.Citas.CrearCita(nuevaCita);
                await _unitOfWork.SaveChangesAsync();

                // Mapea la entidad Cita creada a un DTO y devuélvela
                return _mapper.Map<CitaDTO>(nuevaCita);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la cita: " + ex.Message);
            }
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
