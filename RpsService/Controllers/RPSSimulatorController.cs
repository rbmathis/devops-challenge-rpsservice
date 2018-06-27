using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RPSService.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class RpsSimulatorController : ControllerBase
    {
        public enum RockPaperScissors
        {
            Rock = 0,
            Paper,
            Scissors
        }

        // GET api/rpssimulator
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(RockPaperScissors))]
        public IActionResult Get()
        {
            int seed = (int)System.DateTime.Now.Ticks;
            return this.Get(seed);
        }
        

        // GET api/rpssimulator/1
        [HttpGet("{seed}")]
        [ProducesResponseType(200, Type = typeof(RockPaperScissors))]
        public IActionResult Get(int seed)
        {
            var rnd = new Random(seed);
            return Ok((RockPaperScissors)(rnd.Next(3)));
        }

        // GET api/rpssimulator/0-0
        [HttpGet("{player1}-{player2}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult Get(RockPaperScissors player1, RockPaperScissors player2)
        {
            if (player1 == player2) return Ok(0); // tie
            
            // Check all player 1 wins combinations
            if ((player1 == RockPaperScissors.Rock && player2 == RockPaperScissors.Scissors)
                || (player1 == RockPaperScissors.Paper && player2 == RockPaperScissors.Rock)
                || (player1 == RockPaperScissors.Scissors && player2 == RockPaperScissors.Paper))
            {
                return Ok(1);                
            }

            // What's left means player 2 wins
            return Ok(2);
        }
    }
}
