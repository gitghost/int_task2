using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task2.Controllers
{
    [Route("api/croom")]
    public class ConferenceRoomController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Podaj numer pokoju" };
        }

        // GET api/<controller>/5
        [HttpGet("{nr:int}")]
        public IActionResult Get(int nr)
        {
            return Ok();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] ConferenceRoom pokoj)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("get",pokoj.Number);
        }

        // PUT api/<controller>/5
        [HttpPut("{nr:int}")]
        public void Put(int nr, [FromBody]string capacity,[FromBody] bool rzutnik)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{nr:int}")]
        public void Delete(int nr)
        {
            //sprawdzić czy pokój istnieje

            //usunąć pokój

        }
    }
}
