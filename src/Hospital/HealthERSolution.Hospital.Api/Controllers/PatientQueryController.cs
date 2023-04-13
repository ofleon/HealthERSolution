using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HealthERSolution.Hospital.Api.Controllers
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
            string sql = @"SELECT pm.Id,
                            pm.Name,
                            Sex = 
                            CASE pm.Sex
	                            WHEN 0 THEN 'Male'
	                            WHEN 1 THEN 'Female'
                            END,
                            pm.DateOfBirth,
                            p.BloodType, 
                            p.Weight, 
                            p.Status, 
                            p.UpdatedOn
                            FROM PatientsMetadata pm 
                            JOIN Patients p
                            ON pm.Id = p.Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("Hospital"));
            var orderDetail = (await connection.QueryAsync(sql)).ToList();
            return Ok(orderDetail);
        }
    }
}
