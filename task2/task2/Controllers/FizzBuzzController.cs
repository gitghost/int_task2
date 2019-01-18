using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task2.Controllers
{
    [Route("api/[controller]")]
    public class FizzBuzzController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Log.Debug("FizzBuzz Get - nieprawidłowe dane!");
            return new string[] { "Podaj numer od 0 do 1000" };
        }


        [HttpGet("{digit:range(0,1000)}")]
        public string Get(int digit)
        {
            string wynik = FizzBuzz(digit);
            Log.Information("Podano "+digit+" zwrócono "+wynik);
            return wynik;          
        }

        // POST api/<controller>        - post/put/delete niepotrzebne?
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public static string FizzBuzz(int digit)
        {

        if (digit % 2 == 0 && digit % 3 == 0)
        {
            return "FizzBuzz";               
        }                                                   
            else if (digit % 2 == 0 && digit % 3 != 0)
            {
                return "Fizz";
            }
            else if (digit % 2 != 0 && digit % 3 == 0)
            {
                return "Buzz";
            }
            else
            {
                return "*niepodzielna przez 2 i 3*";
            }
        }
    }
}
