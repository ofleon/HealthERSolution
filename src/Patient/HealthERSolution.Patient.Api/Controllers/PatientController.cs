using HealthERSolution.Patient.Api.ApplicationServices;
using HealthERSolution.Patient.Api.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HealthERSolution.Patient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientApplicationService patientApplicationService;
        private readonly ILogger<PatientController> logger;

        public PatientController(PatientApplicationService patientApplicationService,
                             ILogger<PatientController> logger)
        {
            this.patientApplicationService = patientApplicationService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePatientCommand command)
        {
            try
            {
                await patientApplicationService.HandleCommandAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("name")]
        public async Task<IActionResult> Put(SetNameCommand command)
        {
            try
            {
                await patientApplicationService.HandleCommandAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("dateofbirth")]
        public async Task<IActionResult> Put(SetDateOfBirthCommand command)
        {
            try
            {
                await patientApplicationService.HandleCommandAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("transfertohospital")]
        public async Task<IActionResult> Post(TransferToHospitalCommand command)
        {
            try
            {
                await patientApplicationService.HandleCommandAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
