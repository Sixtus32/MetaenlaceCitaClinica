using AutoMapper;
using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository;
using MetaenlaceCitaClinica.Services.Impl;
using Microsoft.EntityFrameworkCore;


namespace MetaenlaceCitaClinica.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MedicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // Serv.    Actualizar Medico
        public async Task ActualizarMedico(int idMedico, MedicoRequestDTO medico)
        {
            var medicoExistente = await _unitOfWork.Medicos.ObtenerIdMedico(idMedico) ?? throw new ArgumentException("El paciente no existe");
            // Actualizar las propiedades del usuario existente con los nuevos valores
            medicoExistente.Nombre = medico.Nombre;
            medicoExistente.Apellidos = medico.Apellidos;
            medicoExistente.UsuarioNom = medico.UsuarioNom;
            medicoExistente.Clave = medico.Clave;


            // campos propios
            medicoExistente.NumColegiado = medico.NumColegiado;
            await _unitOfWork.SaveChangesAsync();
        }

        // Serv.    Crear Medico
        public async Task<MedicoDTO> CrearMedico(MedicoRequestDTO medico)
        {
            var nuevoMedico = _mapper.Map<Medico>(medico);
            await _unitOfWork.Medicos.CrearMedico(nuevoMedico);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MedicoDTO>(nuevoMedico);
        }

        // Serv.    Eliminar Medico
        public async Task EliminarMedico(int idMedico)
        {
            var medico = await _unitOfWork.Medicos.ObtenerIdMedico(idMedico) ?? throw new ArgumentException("El medico no existe");
            await _unitOfWork.Medicos.EliminarMedico(medico);
            await _unitOfWork.SaveChangesAsync();
        }


        // Serv.    Obtener Medico Por Id
        public async Task<MedicoDTO> ObtenerMedicoPorId(int idMedico)
        {
            var medico = await _unitOfWork.Medicos.ObtenerIdMedico(idMedico);
            var medicoDTO = _mapper.Map<MedicoDTO>(medico);
            return medicoDTO;
        }


        // Serv.    Listar Medico
        public async Task<IEnumerable<MedicoDTO>> ObtenerTodosMedicos()
        {
            var medicos = await _unitOfWork.Medicos.ObtenerMedicos();
            var medicosDTO = _mapper.Map<IEnumerable<Medico>, IEnumerable<MedicoDTO>>(medicos);
            return medicosDTO;
        }
    }
}
