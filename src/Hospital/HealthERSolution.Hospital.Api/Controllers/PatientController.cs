using HealthERSolution.Hospital.Api.ApplicationServices;
using HealthERSolution.Hospital.Api.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HealthERSolution.Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalApplicationService applicationService;
        private readonly ILogger<PatientController> logger;

        public PatientController(HospitalApplicationService applicationService,
                                 ILogger<PatientController> logger)
        {
            this.applicationService = applicationService;
            this.logger = logger;
        }

        [HttpPut("weight")]
        public async Task<IActionResult> Put(SetWeightCommand command)
        {
            try
            {
                await applicationService.HandleAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("bloodType")]
        public async Task<IActionResult> Put(SetBloodTypeCommand command)
        {
            try
            {
                await applicationService.HandleAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("admit")]
        public async Task<IActionResult> Post(AdmitPatientCommand command)
        {
            try
            {
                await applicationService.HandleAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("discharge")]
        public async Task<IActionResult> Post(DischargePatientCommand command)
        {
            try
            {
                await applicationService.HandleAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("procedure")]
        public async Task<IActionResult> Post(AddProcedureCommand command)
        {
            try
            {
                await applicationService.HandleAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
