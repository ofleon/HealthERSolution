using HealthERSolution.Hospital.Domain.Repositories;
using HealthERSolution.Hospital.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthERSolution.Hospital.Analytic;

public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IPatientAggregateStore, PatientAggregateStore>();
            })
            .Build();

        host.Run();
    }
}
