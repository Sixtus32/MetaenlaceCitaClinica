using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Ignore
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> ObtenerUsuarioPorId(int idUsuario);        // [Serv.   Obtener Usuario Por id]
        Task<IEnumerable<UsuarioDTO>> ObtenerTodosUsuarios();       // [Serv.   Listar Usuarios]
        Task<UsuarioDTO> CrearUsuario(UsuarioDTO usuario);          // [Serv.   Crear Usuario]
        Task ActualizarUsuario(int idUsuario, UsuarioDTO usuario);  // [Serv.   Actualizar Usuario]
        Task EliminarUsuario(int idUsuario);                        // [Serv.   Eliminar Usuario]
    }
}
