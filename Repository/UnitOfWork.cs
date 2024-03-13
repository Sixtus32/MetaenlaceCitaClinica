using MetaenlaceCitaClinica.Models.Data;
using MetaenlaceCitaClinica.Models.Entity;
using MetaenlaceCitaClinica.Repository.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MetaenlaceCitaClinica.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IPacienteRepository Pacientes { get; }
        IMedicoRepository Medicos { get; }
        ICitaRepository Citas { get; }
        IDiagnosticoRepository Diagnosticos { get; }
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly CitaClinicaDataContext _context;

        public UnitOfWork(CitaClinicaDataContext context)
        {
            _context = context;
            Pacientes = new PacienteRepository(_context);
            Medicos = new MedicoRepository(_context);
            Citas = new CitaRepository(_context);
            Usuarios = new UsuarioRepository(_context);
            Diagnosticos = new DiagnosticoRepository(_context);
        }

        public IPacienteRepository Pacientes { get; }
        public IMedicoRepository Medicos { get; }
        public ICitaRepository Citas { get; }
        public IUsuarioRepository Usuarios { get; }
        public IDiagnosticoRepository Diagnosticos { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
