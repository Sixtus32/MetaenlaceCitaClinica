using AutoMapper;
using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // PARA CITAS
            CreateMap<CitaDTO, Cita>();
            CreateMap<Cita, CitaDTO>();
            CreateMap<CitaRequestDTO, Cita>();
            CreateMap<Cita, CitaRequestDTO>();

            // PARA DIAGNOSTICOS
            CreateMap<DiagnosticoDTO, Diagnostico>();
            CreateMap<Diagnostico, DiagnosticoDTO>();

            // PARA MEDICO
            CreateMap<MedicoDTO, Medico>();
            CreateMap<Medico, MedicoDTO>();
            CreateMap<MedicoRequestDTO, Medico>();
            CreateMap<Medico, MedicoRequestDTO>();

            // PARA PACIENTE
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteRequestDTO, Paciente>();
            CreateMap<Paciente, PacienteRequestDTO>();
        }
    }

}
