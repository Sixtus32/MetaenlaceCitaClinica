using AutoMapper;
using MetaenlaceCitaClinica.Models.Data;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository.Impl;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MetaenlaceCitaClinica.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSet<Usuario> _usuarioSet;
        private readonly CitaClinicaDataContext _context;

        public UsuarioRepository(CitaClinicaDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _usuarioSet = context.Set<Usuario>();
        }

        // Repo.    Actualizar usuario
        public async Task ActualizarUsuario(Usuario usuario)
        {
            _usuarioSet.Attach(usuario);
            _usuarioSet.Update(usuario);
        }

        // Repo.    Crear usuario
        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            await  _usuarioSet.AddAsync(usuario);
            return usuario;
        }

        // Repo.    Eliminar Usuario
        public async Task EliminarUsuario(Usuario usuario)
        {
            _usuarioSet.Remove(usuario);
        }

        // Repo.    Listar Usuarios
        public async Task<IEnumerable<Usuario>> ObtenerListaDeUsuario()
        {
            return await _usuarioSet.ToListAsync();
        }

        // Repo.    Obtener Usuario por Id
        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            try
            {
                Usuario? usuario = await _usuarioSet.FindAsync(id);
                return usuario ?? throw new Exception($"No se encontró un usuario con el ID {id}.");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL OBTENER UN USUARIO: " + ex.Message);
            }
        }
    }
}
