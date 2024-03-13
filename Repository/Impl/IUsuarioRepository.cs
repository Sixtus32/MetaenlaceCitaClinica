using MetaenlaceCitaClinica.Models.Entity;

namespace MetaenlaceCitaClinica.Repository.Impl
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtenerUsuarioPorId(int id);                      // [Repo.   Obtener Usuario Entity]
        Task<IEnumerable<Usuario>> ObtenerListaDeUsuario();             // [Repo.   Listar Usuarios Entity]
        Task<Usuario> CrearUsuario(Usuario usuario);                    // [Repo.   Crear Usuario Entity]
        Task ActualizarUsuario(Usuario usuario);                        // [Repo.   Actualizar Usuario Entity]
        Task EliminarUsuario(Usuario usuario);                          // [Repo.   Eliminar Usuario Entity]
    }
}
