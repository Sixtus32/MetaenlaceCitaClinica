using MetaenlaceCitaClinica.Models.Data;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository.Impl;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceCitaClinica.Repository
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly DbSet<Diagnostico> _diagnosticoSet;
        private readonly CitaClinicaDataContext _context;

        public DiagnosticoRepository(CitaClinicaDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _diagnosticoSet = context.Set<Diagnostico>();
        }

        public async Task ActualizarDiagnostico(Diagnostico diagnostico)
        {
            _diagnosticoSet.Attach(diagnostico);
            _diagnosticoSet.Update(diagnostico);
        }

        public async Task<Diagnostico> CrearDiagnostico(Diagnostico diagnostico)
        {
            // Verificar si ya existe un diagnóstico con el mismo CitaID
            var existingDiagnostico = await _diagnosticoSet.FirstOrDefaultAsync(d => d.CitaID == diagnostico.CitaID);
            if (existingDiagnostico != null)
            {
                // Si ya existe un diagnóstico con el mismo CitaID, retornar ese diagnóstico
                return existingDiagnostico;
            }
            else
            {
                // Si no existe un diagnóstico con el mismo CitaID, agregar el nuevo diagnóstico
                await _diagnosticoSet.AddAsync(diagnostico);
                return diagnostico;
            }
        }

        public async Task EliminarDiagnostico(Diagnostico diagnostico)
        {
            _diagnosticoSet.Remove(diagnostico);
        }

        public async Task<IEnumerable<Diagnostico>> ObtenerDiagnosticos()
        {
            return await _diagnosticoSet.ToListAsync();
        }

        public async Task<Diagnostico> ObtenerIdDiagnostico(int id)
        {
            try
            {
                Diagnostico? diagnostico = await _diagnosticoSet.FindAsync(id);
                return diagnostico ?? throw new Exception($"No se encontró un diagnóstico con el ID {id}.");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL OBTENER UN DIAGNÓSTICO: " + ex.Message);
            }
        }
    }
}
