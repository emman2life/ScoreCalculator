using BowlingCalculatorAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalculatorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private readonly IGameCalculator gameCalculator;

        public BowlingController(IGameCalculator gameCalculator)
        {
            this.gameCalculator = gameCalculator;
        }

        [HttpGet]
        public DisplayFrame Get()
        {


            return gameCalculator.CalculateGame();
        }
        [HttpGet]
        public DisplayFrame Reset()
        {
            gameCalculator.Initialize();

            return gameCalculator.CalculateGame();
        }
        [HttpPost]
        public DisplayFrame Post([FromBody] KnockedPins pins )
        {
            gameCalculator.KnockedPins(pins.Pins);

            return gameCalculator.CalculateGame();
            //return framelist.ToList();
        }
       

    }
}
