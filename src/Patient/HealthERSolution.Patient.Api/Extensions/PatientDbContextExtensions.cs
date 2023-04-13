using HealthERSolution.Patient.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HealthERSolution.Patient.Api.Extensions;

public static class PatientDbContextExtensions
{
    public static void AddPatientDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PatientDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Pet"));
        });
    }
    public static void EnsurePetDbIsCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<PatientDbContext>();
        context.Database.EnsureCreated();
        context.Database.CloseConnection();
    }
}
