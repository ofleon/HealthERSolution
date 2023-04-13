using HealthERSolution.Hospital.Domain.Repositories;
using HealthERSolution.Hospital.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IPatientAggregateStore, PatientAggregateStore>();
    })
    .Build();

host.Run();