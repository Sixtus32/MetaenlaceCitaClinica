using Microsoft.AspNetCore.Mvc;
using MetaenlaceCitaClinica.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetaenlaceCitaClinica.Services.Impl;
using MetaenlaceCitaClinica.Models.DTOs;
using MetaenlaceCitaClinica.Models.DTOs.RequestDTO;

namespace MetaenlaceCitaClinica.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con diagnósticos médicos.
    /// </summary>
    [Route("api/v1/")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService _diagnosticoService;

        /// <summary>
        /// Constructor del controlador de diagnósticos.
        /// </summary>
        /// <param name="diagnosticoService">Servicio de diagnósticos</param>
        public DiagnosticoController(IDiagnosticoService diagnosticoService)
        {
            _diagnosticoService = diagnosticoService ?? throw new ArgumentNullException(nameof(diagnosticoService));
        }

        /// <summary>
        /// Obtiene todos los diagnósticos.
        /// </summary>
        /// <returns>Una lista de diagnósticos</returns>
        [HttpGet("diagnosticos")]
        [ProducesResponseType(typeof(IEnumerable<DiagnosticoDTO>), 200)]
        public async Task<ActionResult<IEnumerable<DiagnosticoDTO>>> ObtenerTodosDiagnosticos()
        {
            var diagnosticos = await _diagnosticoService.ObtenerTodosDiagnostico();
            return Ok(diagnosticos);
        }

        /// <summary>
        /// Obtiene un diagnóstico por su ID.
        /// </summary>
        /// <param name="idDiagnostico">ID del diagnóstico a obtener</param>
        /// <returns>El diagnóstico encontrado</returns>
        [HttpGet("diagnostico/{idDiagnostico}")]
        [ProducesResponseType(typeof(DiagnosticoDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DiagnosticoDTO>> ObtenerDiagnosticoPorId(int idDiagnostico)
        {
            var diagnostico = await _diagnosticoService.ObtenerDiagnosticoPorId(idDiagnostico);
            if (diagnostico == null)
            {
                return NotFound();
            }
            return Ok(diagnostico);
        }

        /// <summary>
        /// Crea un nuevo diagnóstico.
        /// </summary>
        /// <param name="diagnosticoDTO">Datos del diagnóstico a crear</param>
        /// <returns>El diagnóstico creado</returns>
        [HttpPost("diagnostico")]
        [ProducesResponseType(typeof(DiagnosticoDTO), 201)]
        public async Task<ActionResult<DiagnosticoDTO>> CrearDiagnostico(DiagnosticoRequestDTO diagnosticoDTO)
        {
            var nuevoDiagnostico = await _diagnosticoService.CrearDiagnostico(diagnosticoDTO);
            return CreatedAtAction(nameof(ObtenerDiagnosticoPorId), new { idDiagnostico = nuevoDiagnostico.DiagnosticoID }, nuevoDiagnostico);
        }

        /// <summary>
        /// Actualiza los datos de un diagnóstico existente.
        /// </summary>
        /// <param name="idDiagnostico">ID del diagnóstico a actualizar.</param>
        /// <param name="diagnosticoDTO">Nuevos datos del diagnóstico.</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpPut("diagnostico/{idDiagnostico}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ActualizarDiagnostico(int idDiagnostico, DiagnosticoRequestDTO diagnosticoDTO)
        {
            try
            {
                await _diagnosticoService.ActualizarDiagnostico(idDiagnostico, diagnosticoDTO);
                return NoContent(); // Se devuelve NoContent cuando la actualización se realiza con éxito
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Se devuelve NotFound si el diagnóstico no existe
            }
        }

        /// <summary>
        /// Elimina un diagnóstico existente.
        /// </summary>
        /// <param name="idDiagnostico">ID del diagnóstico a eliminar</param>
        /// <returns>Respuesta HTTP sin contenido.</returns>
        [HttpDelete("diagnostico/{idDiagnostico}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarDiagnostico(int idDiagnostico)
        {
            try
            {
                await _diagnosticoService.EliminarDiagnostico(idDiagnostico);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
