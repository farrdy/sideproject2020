using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RatesCalculator.Models;
using RatesCalculator.Service.Interfaces;

namespace RatesCalculator.Intranet.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RatesTariffsController : ControllerBase
    {

        private IRefuseService _refuseService = null;
        private ISanitationService _sanitation = null;
        private IWaterService _waterService = null;

        private IElectricityService _electricityService = null;

        public RatesTariffsController(IRefuseService _service, ISanitationService sanitation, IWaterService waterService)
        {
            _refuseService = _service;
            _sanitation = sanitation;
            _waterService = waterService;
        }


        /// <summary>
        /// Calculate all  residence refuse charges.
        /// </summary>
        /// <param name="input">The input parameters</param>
        /// <returns>Refuse amount</returns>

        [HttpPost]
        [Route("/Refuse")]
        public IActionResult Refuse([FromBody] RefuseIn input)
        {

            var refuseAmount = _refuseService.CalculateRefuse(input);
            if (refuseAmount == null)
            {
                return NotFound("There was en error, refuse could not be calculated");
            }

            return Ok(refuseAmount);
        }

        /// <summary>
        /// Calculate all  residence electricity charges.
        /// </summary>
        /// <param name="input">The input parameters</param>
        /// <returns>Electricity amount</returns>
        [HttpPost]
        [Route("/Eletricity")]
        public IActionResult Electricity([FromBody] ElectricityIn input)
        {
            var electricityAmount = _electricityService.CalculateElectricity(input);

            if (electricityAmount ==null)
            {
                return NotFound("There was en error, refuse could not be calculated");
            }
            return Ok();
        }


        /// <summary>
        /// Calculate all  residence water charges.
        /// </summary>
        /// <param name="input">The input parameters</param>
        /// <returns>Water amount</returns>
        [HttpPost]
        [Route("/Water")]
        public IActionResult Water([FromBody] WaterIn input)
        {
            var waterAmount = _waterService.CalculateWater(input);
            if (waterAmount == null)
            {
                return NotFound("There was en error, water could not be calculated");
            }

            return Ok(waterAmount);
        }


        /// <summary>
        /// Calculate all residence sanitation charges.
        /// </summary>
        /// <param name="input">The input parameters</param>
        /// <returns>Sanitation amount</returns>
        [HttpPost]
        [Route("/Sanitation")]
        public IActionResult Sanitation([FromBody] SanitationIn input)
        {
            var sanitationAmount = _sanitation.CalculateSanitation(input);
            if (sanitationAmount == null)
            {
                return NotFound("There was en error, sanitation could not be calculated");
            }

            return Ok(sanitationAmount);
        }
        /// <summary>
        /// Calculate all residence charges.
        /// </summary>
        /// <param name="input">The input parameters</param>
        /// <returns>All amount</returns>

        [HttpPost]
        [Route("/ComputeAllTariffs")]
        public IActionResult ComputeAllTariffs()
        {
            var rng = new Random();
            return Ok();
        }
    }
}
