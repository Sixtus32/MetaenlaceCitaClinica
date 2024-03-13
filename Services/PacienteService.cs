using AutoMapper;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Models.DTOs.ResponseDTO;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository;
using MetaenlaceCitaClinica.Services.Impl;

namespace MetaenlaceCitaClinica.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PacienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // Serv.        Actualizar Paciente
        public async Task ActualizarPaciente(int idPaciente, PacienteRequestDTO paciente)
        {
            var pacienteExistente = await _unitOfWork.Pacientes.ObtenerId(idPaciente) ?? throw new ArgumentException("El paciente no existe");
            // Actualizar las propiedades del usuario existente con los nuevos valores
            pacienteExistente.Nombre = paciente.Nombre;
            pacienteExistente.Apellidos = paciente.Apellidos;
            pacienteExistente.UsuarioNom = paciente.UsuarioNom;
            pacienteExistente.Clave = paciente.Clave;

            // campos propios
            pacienteExistente.NSS = paciente.NSS;
            pacienteExistente.NumTarjeta = paciente.NumTarjeta;
            pacienteExistente.Telefono = paciente.Telefono;
            pacienteExistente.Direccion = paciente.Direccion;
            await _unitOfWork.SaveChangesAsync();
        }

        // Serv.        Crear Paciente
        public async Task<PacienteDTO> CrearPaciente(PacienteRequestDTO paciente)
        {
            var nuevoPaciente = _mapper.Map<Paciente>(paciente);
            await _unitOfWork.Pacientes.CrearPaciente(nuevoPaciente);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PacienteDTO>(nuevoPaciente);
        }



        // Serv.        Eliminar Paciente
        public async Task EliminarPaciente(int idPaciente)
        {
            var paciente = await _unitOfWork.Pacientes.ObtenerId(idPaciente) ?? throw new ArgumentException("El paciente no existe");
            await _unitOfWork.Pacientes.EliminarPaciente(paciente);
            await _unitOfWork.SaveChangesAsync();
        }


        // Serv.        Obtener Paciente Por Id
        public async Task<PacienteDTO> ObtenerPacientePorId(int idPaciente)
        {
            var paciente = await _unitOfWork.Pacientes.ObtenerId(idPaciente);
            var pacienteDTO = _mapper.Map<PacienteDTO>(paciente);
            return pacienteDTO;
        }


        // Serv.        Listar Paciente
        public async Task<IEnumerable<PacienteDTO>> ObtenerTodosPacientes()
        {
            var pacientes = await _unitOfWork.Pacientes.ObtenerTodos();
            var pacientesDTO = _mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteDTO>>(pacientes);
            return pacientesDTO;
        }
    }
}
