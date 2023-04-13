using HealthERSolution.Hospital.Domain.Repositories;
using HealthERSolution.Hospital.Domain.ValueObjects;
using HealthERSolution.Hospital.Infrastructure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HealthERSolution.Hospital.Analysis
{
    public class PatientsAnalysis
    {
        private readonly IConfiguration configuration;
        private readonly IPatientAggregateStore patientAggregateStore;
        public PatientsAnalysis(IConfiguration configuration, IPatientAggregateStore patientAggregateStore)
        {
            this.configuration = configuration;
            this.patientAggregateStore = patientAggregateStore;
        }

        [Function("PatientsAnalysis")]
        public async Task Run([CosmosDBTrigger(
            databaseName: "HealthERSolution",
            collectionName: "Patients",
            ConnectionStringSetting = "CosmosDbConnectionString", //this should be provide by AzureCosmos Db or CosmosDb Emulator
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")] IReadOnlyList<CosmosEventData> input, FunctionContext context)
        {
            var logger = context.GetLogger("PatientsAnalysis");
            if (input == null || !input.Any())
            {
                return;
            }

            logger.LogInformation("Items received: " + input.Count);

            using var conn = new SqlConnection(configuration.GetConnectionString("Hospital"));
            conn.EnsurePatientsTable();

            foreach (var item in input)
            {
                var patientId = Guid.Parse(item.AggregateId.Replace("Patient-", string.Empty));
                var patient = await patientAggregateStore.LoadAsync(PatientId.Create(patientId));

                conn.InsertPatient(patient);
                logger.LogInformation(item.Data);
            }

            conn.Close();
        }
    }
}
