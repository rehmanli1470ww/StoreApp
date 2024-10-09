using LogService.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        // GET: api/<LogController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogController>
        [HttpPost("LogMessage")]
        public IActionResult Post([FromBody] MessageDto dto)
        {
            try
            {
                var path = "Log.txt";
                var message = dto.Message + " this image added cloud at " + dto.Date.ToShortDateString() + " " + dto.Date.ToShortTimeString();

                System.IO.File.AppendAllText(path, message);
                return Ok();

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }
        //dto.Date.Year + " " + dto.Date.Month + " " + dto.Date.Day + " "
        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
