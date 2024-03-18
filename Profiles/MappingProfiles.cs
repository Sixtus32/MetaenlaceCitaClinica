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
            CreateMap<DiagnosticoRequestDTO, Cita>();
            CreateMap<Cita, DiagnosticoRequestDTO>();

            // PARA MEDICO
            CreateMap<Medico, MedicoDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.UsuarioID)) // Mapea el UsuarioID al ID del DTO
                .ReverseMap();
            CreateMap<MedicoRequestDTO, Medico>().ReverseMap();
            CreateMap<Medico, MedicoRequestDTO>();

            // PARA PACIENTE
            CreateMap<Paciente, PacienteDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.UsuarioID)) // Mapea el UsuarioID al ID del DTO
                .ReverseMap();
            CreateMap<PacienteRequestDTO, Paciente>().ReverseMap();
            CreateMap<Paciente, PacienteRequestDTO>();
        }
    }

}
