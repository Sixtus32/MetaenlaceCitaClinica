using MetaenlaceCitaClinica.Models.Data;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository.Impl;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceCitaClinica.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly DbSet<Medico> _medicoSet;
        private readonly CitaClinicaDataContext _context;

        public MedicoRepository(CitaClinicaDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _medicoSet = context.Set<Medico>();
        }

        // Repo Actualiza Medico
        public async Task ActualizarMedico(Medico medico)
        {
            _medicoSet.Attach(medico);
            _medicoSet.Update(medico);
        }


        // Repo.    Eliminar Medico
        public async Task EliminarMedico(Medico medico)
        {
            _medicoSet.Remove(medico);
        }


        // Repo.    Obtener Medico por id
        public async Task<Medico> ObtenerIdMedico(int id)
        {
            try
            {
                Medico? medico = await _medicoSet.FindAsync(id);
                return medico ?? throw new Exception($"No se encontró un médico con el ID {id}.");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL OBTENER UN MÉDICO: " + ex.Message);
            }
        }

        // Repo.    Listar Medico
        public async Task<IEnumerable<Medico>> ObtenerMedicos()
        {
            return await _medicoSet.ToListAsync();
        }

        // Repo.    Crear Medico
        public async Task<Medico> CrearMedico(Medico medico)
        {
            await _medicoSet.AddAsync(medico);
            return medico;
        }

    }
}
