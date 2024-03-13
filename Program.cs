using MetaenlaceCitaClinica.Profiles;
using MetaenlaceCitaClinica.Models.Data;
using MetaenlaceCitaClinica.Repository;
using MetaenlaceCitaClinica.Services;
using Microsoft.EntityFrameworkCore;
using MetaenlaceCitaClinica.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfiles));


// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(UnitOfWork));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped(typeof(UsuarioService));

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped(typeof(PacienteService));

builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped(typeof(MedicoService));

builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped(typeof(CitaService));

builder.Services.AddScoped<IDiagnosticoService, DiagnosticoService>();
builder.Services.AddScoped(typeof(DiagnosticoService));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CitaClinicaDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();