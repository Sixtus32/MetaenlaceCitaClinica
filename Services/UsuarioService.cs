using AutoMapper;
using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository;
using MetaenlaceCitaClinica.Repository.Impl;
using MetaenlaceCitaClinica.Services.Impl;
using System.Threading.Tasks;

namespace MetaenlaceCitaClinica.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // Service.     Actualizar Usuario
        public async Task ActualizarUsuario(int idUsuario, UsuarioDTO usuarioDTO)
        {
            var usuarioExistente = await _unitOfWork.Usuarios.ObtenerUsuarioPorId(idUsuario) ?? throw new ArgumentException("El usuario no existe");
            // Actualizar las propiedades del usuario existente con los nuevos valores
            usuarioExistente.Nombre = usuarioDTO.Nombre;
            usuarioExistente.Apellidos = usuarioDTO.Apellidos;
            usuarioExistente.UsuarioNom = usuarioDTO.UsuarioNom;
            usuarioExistente.Clave = usuarioDTO.Clave;
            await _unitOfWork.SaveChangesAsync();
        }


        // Service.     Crear Usuario
        public async Task<UsuarioDTO> CrearUsuario(UsuarioDTO usuario)
        {
            var nuevoUsuario = _mapper.Map<Usuario>(usuario);
            await _unitOfWork.Usuarios.CrearUsuario(nuevoUsuario);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UsuarioDTO>(nuevoUsuario);
        }


        // Service.     Eliminar Usuario
        public async Task EliminarUsuario(int idUsuario)
        {
            var usuario = await _unitOfWork.Usuarios.ObtenerUsuarioPorId(idUsuario) ?? throw new ArgumentException("El usuario no existe");
            await _unitOfWork.Usuarios.EliminarUsuario(usuario);
            await _unitOfWork.SaveChangesAsync();
        }


        // Service.     Listar Usuarios
        public async Task<IEnumerable<UsuarioDTO>> ObtenerTodosUsuarios()
        {
            var usuarios = await _unitOfWork.Usuarios.ObtenerListaDeUsuario();
            var usuariosDTO =  _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioDTO>>(usuarios);
            return usuariosDTO;
        }


        // Service.     Obtener Usuario Por Id
        public async Task<UsuarioDTO> ObtenerUsuarioPorId(int idUsuario)
        {
            var usuario = await _unitOfWork.Usuarios.ObtenerUsuarioPorId(idUsuario);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }
    }
}
