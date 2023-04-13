using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HealthERSolution.Patient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientQueryController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public PatientQueryController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string query = @"SELECT p.Id, p.Name_Value as Name,
                            Sex = 
                            CASE p.SexOfPatient_Value
                              WHEN 0 THEN 'Male'
                              WHEN 1 THEN 'Female'
                            END,
                            p.DateOfBirth_Value as DateOfBirth
                            FROM Patients p";
            using var connection = new SqlConnection(configuration.GetConnectionString("Patient"));
            var orderDetail = (await connection.QueryAsync(query)).ToList();
            return Ok(orderDetail);
        }
    }
}
