using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using RatesCalculator.Models;
using RatesCalculator.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RatesCalculator.Intranet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        // GET: api/<LookupsController>
        private IWaterMeterRepository _waterMeter = null;
        private IIndigentIncomeRepository _indigentincomeLevels = null;
        private IIncomeDisbaledPensionerRepository _pensionerDisabledLevels = null;
        public LookupsController(IWaterMeterRepository waterMeter, IIndigentIncomeRepository incomeLevels, IIncomeDisbaledPensionerRepository pensionerDisbaledIncomelvs)
        {
            _waterMeter = waterMeter;
            _indigentincomeLevels = incomeLevels;
            _pensionerDisabledLevels = pensionerDisbaledIncomelvs;

        }

        /// <summary>
        /// Meter Sizes and charges.
        /// </summary>       
        /// <returns>List of water meters amount</returns>
        [HttpGet("/WaterMeter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetWaterMeter()
        {

            var waterMeters = _waterMeter.GetAll();
            if (waterMeters == null || waterMeters.Count() < 1)
            {
                return NotFound("There was en error, water meters could not be found");
            }

            return Ok(waterMeters);
        }


        /// <summary>
        /// Indigent Income levels.
        /// </summary>       
        /// <returns>List of indidigent income levels</returns>
        [HttpGet("/IndigentIncomelvl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetIncomeLevels()
        {
            var incomeLevels = _indigentincomeLevels.GetAll();
            if (incomeLevels == null || _indigentincomeLevels.Count() < 1)
            {
                return NotFound("There was en error, income levels could not be found");
            }

            return Ok(incomeLevels);
        }



        /// <summary>
        /// Pensioner Disabled Income levels.
        /// </summary>       
        /// <returns>List of indidigent income levels</returns>

        [HttpGet("/PensionerDisabledIncomelvl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PensionerDisabledIncomes()
        {
            var incomeLevels = _pensionerDisabledLevels.GetAll();
            if (incomeLevels == null || _pensionerDisabledLevels.Count() < 1)
            {
                return NotFound("There was en error, income levels could not be found");
            }

            return Ok(incomeLevels);
        }
    }
}
