using HealthERSolution.Patient.Api.ApplicationServices;
using HealthERSolution.Patient.Api.Extensions;
using HealthERSolution.Patient.Api.Infrastructure;
using HealthERSolution.Patient.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPatientDb(builder.Configuration);
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<PatientApplicationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.EnsurePetDbIsCreated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
