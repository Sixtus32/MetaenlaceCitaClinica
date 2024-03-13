using MetaenlaceCitaClinica.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceCitaClinica.Models.Data
{
    public class CitaClinicaDataContext : DbContext
    {
        public CitaClinicaDataContext(DbContextOptions<CitaClinicaDataContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<MedicoPaciente> MedicoPacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MEDICO - PACIENTE 
            modelBuilder.Entity<MedicoPaciente>()
                .HasKey(mp => new { mp.MedicoID, mp.PacienteID });

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.Medico)
                .WithMany(m => m.Pacientes)
                .HasForeignKey(mp => mp.MedicoID);

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.Paciente)
                .WithMany(p => p.Medicos)
                .HasForeignKey(mp => mp.PacienteID);

            // DIAGNOSTICO
            modelBuilder.Entity<Diagnostico>()
                .HasOne(d => d.Cita)
                .WithOne(c => c.Diagnostico)
                .HasForeignKey<Diagnostico>(d => d.CitaID)
                .OnDelete(DeleteBehavior.Cascade); // Elimina el diagnóstico si se elimina la cita

            // CITA MEDICO - 
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.MedicoID)
                .OnDelete(DeleteBehavior.Restrict); // Evita que se eliminen los médicos relacionados con citas

            // CITA PACIENTE
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteID)
                .OnDelete(DeleteBehavior.Restrict); // Evita que se eliminen los pacientes relacionados con citas
        }
    }

}
