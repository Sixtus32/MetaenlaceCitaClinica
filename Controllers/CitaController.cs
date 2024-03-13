using System.Collections.Generic;
using System.Threading.Tasks;
using MetaenlaceCitaClinica.Models.DTOs.ResponseDTO;
using MetaenlaceCitaClinica.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetaenlaceCitaClinica.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con citas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaService _citaService;

        /// <summary>
        /// Constructor del controlador de citas.
        /// </summary>
        /// <param name="citaService">Servicio de citas</param>
        public CitaController(CitaService citaService)
        {
            _citaService = citaService;
        }

        /// <summary>
        /// Obtiene todas las citas
        /// </summary>
        /// <returns>Una lista de citas</returns>
        [HttpGet("/citas")]
        [ProducesResponseType(typeof(IEnumerable<CitaDTO>), 200)]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> ObtenerTodasCitas()
        {
            var citas = await _citaService.ObtenerTodosCitas();
            return Ok(citas);
        }

        /// <summary>
        /// Obtiene una cita por su ID
        /// </summary>
        /// <param name="idCita">ID de la cita a obtener</param>
        /// <returns>La cita encontrada</returns>
        [HttpGet("/cita/{idCita}")]
        [ProducesResponseType(typeof(CitaDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CitaDTO>> ObtenerCitaPorId(int idCita)
        {
            var cita = await _citaService.ObtenerCitaPorId(idCita);

            if (cita == null)
            {
                return NotFound();
            }

            return Ok(cita);
        }

        /// <summary>
        /// Crea una nueva cita
        /// </summary>
        /// <param name="citaDTO">Datos de la cita a crear</param>
        /// <returns>La cita creada</returns>
        [HttpPost("/cita")]
        [ProducesResponseType(typeof(CitaDTO), 201)]
        public async Task<ActionResult<CitaDTO>> CrearCita(CitaDTO citaDTO)
        {
            var nuevaCita = await _citaService.CrearCita(citaDTO);
            return CreatedAtAction(nameof(ObtenerCitaPorId), new { idCita = nuevaCita.CitaID }, nuevaCita);
        }

        /// <summary>
        /// Actualiza los datos de una cita existente.
        /// </summary>
        /// <param name="idCita">ID de la cita a actualizar.</param>
        /// <param name="citaDTO">Nuevos datos de la cita.</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpPut("/cita/{idCita}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ActualizarCita(int idCita, CitaDTO citaDTO)
        {
            try
            {
                await _citaService.ActualizarCita(idCita, citaDTO);
                return NoContent(); // Se devuelve NoContent cuando la actualización se realiza con éxito
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Se devuelve NotFound si la cita no existe
            }
        }

        /// <summary>
        /// Elimina una cita existente
        /// </summary>
        /// <param name="idCita">ID de la cita a eliminar</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpDelete("/cita/{idCita}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarCita(int idCita)
        {
            try
            {
                await _citaService.EliminarCita(idCita);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
