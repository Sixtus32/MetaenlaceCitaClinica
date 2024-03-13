using MetaenlaceCitaClinica.Models.Data;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository.Impl;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceCitaClinica.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DbSet<Paciente> _pacienteSet;
        private readonly CitaClinicaDataContext _context;

        public PacienteRepository(CitaClinicaDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _pacienteSet = context.Set<Paciente>();
        }

        // Repo.    Actualizar paciente
        public async Task ActualizarPaciente(Paciente paciente)
        {
            _pacienteSet.Attach(paciente);
            _pacienteSet.Update(paciente);
        }

        // Repo.    Crear paciente
        public async Task<Paciente> CrearPaciente(Paciente paciente)
        {
            await _pacienteSet.AddAsync(paciente);
            return paciente;
        }

        // Repo.    Eliminar paciente
        public async Task EliminarPaciente(Paciente paciente)
        {
            _pacienteSet.Remove(paciente);
        }


        // Repo.    Obtener paciente por ID
        public async Task<Paciente> ObtenerId(int id)
        {
            try
            {
                Paciente? paciente = await _pacienteSet.FindAsync(id);
                return paciente ?? throw new Exception($"No se encontró un paciente con el ID {id}.");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL OBTENER UN PACIENTE: " + ex.Message);
            }
        }

        // Repo.    Listar Pacientes
        public async Task<IEnumerable<Paciente>> ObtenerTodos()
        {
            return await _pacienteSet.ToListAsync();
        }
    }
}
