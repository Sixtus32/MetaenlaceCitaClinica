using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

/*namespace MetaenlaceCitaClinica.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;


        /// <summary>
        /// Constructor del controlador de usuarios.
        /// </summary>
        /// <param name="usuarioService">Servicio de usuarios</param>
        public UsuarioController(UsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }


        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>Una lista de usuarios</returns>
        [HttpGet("/usuarios")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioDTO>), 200)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObtenerTodosUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosUsuarios();
            return Ok(usuarios);
        }


        /// <summary>
        /// Obtiene un usuario por su ID
        /// </summary>
        /// <param name="idUsuario">ID del usuario a obtener</param>
        /// <returns>El usuario encontrado</returns>
        [HttpGet("/usuario/{idUsuario}")]
        [ProducesResponseType(typeof(UsuarioDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UsuarioDTO>> ObtenerUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorId(idUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="usuarioDTO">Datos del usuario a crear</param>
        /// <returns>El usuario creado</returns>
        [HttpPost("/usuario")]
        [ProducesResponseType(typeof(UsuarioDTO), 201)]
        public async Task<ActionResult<UsuarioDTO>> CrearUsuario(UsuarioDTO usuarioDTO)
        {
            var nuevoUsuario = await _usuarioService.CrearUsuario(usuarioDTO);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { idUsuario = nuevoUsuario.UsuarioID }, nuevoUsuario);
        }


        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a actualizar.</param>
        /// <param name="usuarioDTO">Nuevos datos del usuario.</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpPut("/usuario/{idUsuario}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ActualizarUsuario(int idUsuario, UsuarioDTO usuarioDTO)
        {
            try
            {
                await _usuarioService.ActualizarUsuario(idUsuario, usuarioDTO);
                return NoContent(); // Se devuelve NoContent cuando la actualización se realiza con éxito
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Se devuelve NotFound si el usuario no existe
            }
        }



        /// <summary>
        /// Elimina un usuario existente
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpDelete("/usuario/{idUsuario}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarUsuario(int idUsuario)
        {
            try
            {
                await _usuarioService.EliminarUsuario(idUsuario);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
*/