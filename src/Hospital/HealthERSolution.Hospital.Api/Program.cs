using HealthERSolution.Hospital.Api.ApplicationServices;
using HealthERSolution.Hospital.Api.Extensions;
using HealthERSolution.Hospital.Domain.Repositories;
using HealthERSolution.Hospital.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHospitalDb(builder.Configuration);
builder.Services.AddSingleton<IPatientAggregateStore, PatientAggregateStore>();
builder.Services.AddScoped<HospitalApplicationService>();

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

app.EnsureHospitalDbIsCreated();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
