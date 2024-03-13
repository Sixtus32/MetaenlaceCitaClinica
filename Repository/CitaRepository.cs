using MetaenlaceCitaClinica.Models.Data;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository.Impl;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceCitaClinica.Repository
{
    public class CitaRepository : ICitaRepository
    {
        private readonly DbSet<Cita> _citaSet;
        private readonly CitaClinicaDataContext _context;

        public CitaRepository(CitaClinicaDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _citaSet = context.Set<Cita>();
        }

        public async Task ActualizarCita(Cita cita)
        {
            _citaSet.Update(cita);
        }

        public async Task<Cita> CrearCita(Cita cita)
        {
            await _citaSet.AddAsync(cita);
            return cita;
        }

        public async Task EliminarCita(Cita cita)
        {
            _citaSet.Remove(cita);
        }

        public async Task<IEnumerable<Cita>> ObtenerCitas()
        {
            return await _citaSet.ToListAsync();
        }

        public async Task<Cita> ObtenerIdCita(int id)
        {
            try
            {
                Cita? cita = await _citaSet.FindAsync(id);
                return cita ?? throw new Exception($"No se encontró una cita con el ID {id}.");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL OBTENER UNA CITA: " + ex.Message);
            }
        }
    }
}
