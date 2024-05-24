using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificatesController : ControllerBase
    {
        private readonly ILogger<CertificatesController> _logger;

        public CertificatesController(ILogger<CertificatesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get the maximum count of overlapping validity periods among all certificates for a given owner ID.
        /// </summary>
        /// <param name="ownerId">The certificates owner ID.</param>
        /// <returns>The maximum overlapping validity periods count.</returns>
        /// <response code="200">Maximum overlapping validity periods count.</response>
        /// <response code="404">No certificate found for the given owner ID.</response>
        [HttpGet(Name = "GetMaximumOverlappingCertificateValidityPeriodsCount")]
        public async Task<ActionResult<int>> GetMaximumOverlappingCertificateValidityPeriodsCount(int ownerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}