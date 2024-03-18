using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;
using MetaenlaceCitaClinica.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetaenlaceCitaClinica.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con pacientes
    /// </summary>
    [Route("api/v1/")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;

        /// <summary>
        /// Constructor del controlador de pacientes.
        /// </summary>
        /// <param name="pacienteService">Servicio de pacientes</param>
        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService ?? throw new ArgumentNullException(nameof(pacienteService));
        }

        /// <summary>
        /// Obtiene todos los pacientes
        /// </summary>
        /// <returns>Una lista de pacientes</returns>
        [HttpGet("pacientes")]
        [ProducesResponseType(typeof(IEnumerable<PacienteDTO>), 200)]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> ObtenerTodosPacientes()
        {
            var pacientes = await _pacienteService.ObtenerTodosPacientes();
            return Ok(pacientes);
        }

        /// <summary>
        /// Obtiene un paciente por su ID
        /// </summary>
        /// <param name="idPaciente">ID del paciente a obtener</param>
        /// <returns>El paciente encontrado</returns>
        [HttpGet("paciente/{idPaciente}")]
        [ProducesResponseType(typeof(PacienteDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PacienteDTO>> ObtenerPacientePorId(int idPaciente)
        {
            var paciente = await _pacienteService.ObtenerPacientePorId(idPaciente);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        /// <summary>
        /// Crea un nuevo paciente
        /// </summary>
        /// <param name="pacienteDTO">Datos del paciente a crear</param>
        /// <returns>El paciente creado</returns>
        [HttpPost("paciente")]
        [ProducesResponseType(typeof(PacienteDTO), 201)]
        public async Task<ActionResult<PacienteDTO>> CrearPaciente(PacienteRequestDTO pacienteDTO)
        {
            var nuevoPaciente = await _pacienteService.CrearPaciente(pacienteDTO);
            return CreatedAtAction(nameof(ObtenerPacientePorId), new { idPaciente = nuevoPaciente.ID }, nuevoPaciente);
        }


        /// <summary>
        /// Actualiza los datos de un paciente existente.
        /// </summary>
        /// <param name="idPaciente">ID del paciente a actualizar.</param>
        /// <param name="pacienteDTO">Nuevos datos del paciente.</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpPut("paciente/{idPaciente}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ActualizarPaciente(int idPaciente, PacienteRequestDTO pacienteDTO)
        {
            try
            {
                await _pacienteService.ActualizarPaciente(idPaciente, pacienteDTO);
                return NoContent(); // Se devuelve NoContent cuando la actualización se realiza con éxito
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Se devuelve NotFound si el paciente no existe
            }
        }

        /// <summary>
        /// Elimina un paciente existente
        /// </summary>
        /// <param name="idPaciente">ID del paciente a eliminar</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpDelete("paciente/{idPaciente}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarPaciente(int idPaciente)
        {
            try
            {
                await _pacienteService.EliminarPaciente(idPaciente);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
