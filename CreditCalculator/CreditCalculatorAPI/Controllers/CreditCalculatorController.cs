using CreditCalculator.BLL;
using CreditCalculator.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCalculatorController : ControllerBase
    {
        private ICreditCalculator CreditCalculator { get; set; }


        public CreditCalculatorController(ICreditCalculator creditCalculator)
        {
            this.CreditCalculator = creditCalculator;
        }


        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            PersonInfo personInfo = new PersonInfo
            {
                Age = 45,
                CreditRank = 88,

                FamilyExists = true,
                StationarPhoneExists = true,
                HasVisas = false,
                HasHouse = true,
                HasCar = false,
                WasConvicted = false,
                HasAnotherCredit = true
            };
            var result = this.CreditCalculator.CalcCreditAmount(personInfo);
            return Ok(result);
        }

        [HttpPost]
        [Route("CalculateAvailableAmount")]
        public IActionResult CalculateAvailableAmount(PersonInfo personInfo)
        {
            var result = this.CreditCalculator.CalcCreditAmount(personInfo);
            return Ok(result);
        }
    }
}
