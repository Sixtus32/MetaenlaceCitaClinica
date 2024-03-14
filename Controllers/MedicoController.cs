using System.Collections.Generic;
using System.Threading.Tasks;
using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetaenlaceCitaClinica.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con médicos
    /// </summary>
    [Route("api/v1/")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoService _medicoService;

        /// <summary>
        /// Constructor del controlador de médicos.
        /// </summary>
        /// <param name="medicoService">Servicio de médicos</param>
        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        /// <summary>
        /// Obtiene todos los médicos
        /// </summary>
        /// <returns>Una lista de médicos</returns>
        [HttpGet("medicos")]
        [ProducesResponseType(typeof(IEnumerable<MedicoDTO>), 200)]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> ObtenerTodosMedicos()
        {
            var medicos = await _medicoService.ObtenerTodosMedicos();
            return Ok(medicos);
        }

        /// <summary>
        /// Obtiene un médico por su ID
        /// </summary>
        /// <param name="idMedico">ID del médico a obtener</param>
        /// <returns>El médico encontrado</returns>
        [HttpGet("medico/{idMedico}")]
        [ProducesResponseType(typeof(MedicoDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MedicoDTO>> ObtenerMedicoPorId(int idMedico)
        {
            var medico = await _medicoService.ObtenerMedicoPorId(idMedico);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        /// <summary>
        /// Crea un nuevo médico
        /// </summary>
        /// <param name="medicoDTO">Datos del médico a crear</param>
        /// <returns>El médico creado</returns>
        [HttpPost("medico")]
        [ProducesResponseType(typeof(MedicoDTO), 201)]
        public async Task<ActionResult<MedicoDTO>> CrearMedico(MedicoRequestDTO medicoDTO)
        {
            var nuevoMedico = await _medicoService.CrearMedico(medicoDTO);
            return CreatedAtAction(nameof(ObtenerMedicoPorId), new { idMedico = nuevoMedico.UsuarioID }, nuevoMedico);
        }

        /// <summary>
        /// Actualiza los datos de un médico existente.
        /// </summary>
        /// <param name="idMedico">ID del médico a actualizar.</param>
        /// <param name="medicoDTO">Nuevos datos del médico.</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpPut("medico/{idMedico}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ActualizarMedico(int idMedico, MedicoRequestDTO medicoDTO)
        {
            try
            {
                await _medicoService.ActualizarMedico(idMedico, medicoDTO);
                return NoContent(); // Se devuelve NoContent cuando la actualización se realiza con éxito
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Se devuelve NotFound si el médico no existe
            }
        }

        /// <summary>
        /// Elimina un médico existente
        /// </summary>
        /// <param name="idMedico">ID del médico a eliminar</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpDelete("medico/{idMedico}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarMedico(int idMedico)
        {
            try
            {
                await _medicoService.EliminarMedico(idMedico);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
