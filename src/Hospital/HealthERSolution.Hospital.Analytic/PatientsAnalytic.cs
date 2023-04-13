using HealthERSolution.Hospital.Domain.Repositories;
using HealthERSolution.Hospital.Domain.ValueObjects;
using HealthERSolution.Hospital.Infrastructure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace HealthERSolution.Hospital.Analytic
{
    public class PatientsAnalytic
    {
        private readonly IConfiguration configuration;
        private readonly IPatientAggregateStore patientAggregateStore;
        public PatientsAnalytic(IConfiguration configuration, IPatientAggregateStore patientAggregateStore)
        {
            this.configuration = configuration;
            this.patientAggregateStore = patientAggregateStore;
        }


        [Function("PatientsAnalytic")]
        public async Task Run([CosmosDBTrigger(
            databaseName: "HealthERSolution",
            collectionName: "Patients",
            ConnectionStringSetting = "CosmosDbConnectionString",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")] IReadOnlyList<CosmosEventData> input, FunctionContext context)
        {
            var logger = context.GetLogger("PatientsProjector");
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
