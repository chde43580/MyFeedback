using Microsoft.AspNetCore.Mvc;

using MyFeedback.Application.Query;
using MyFeedback.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFeedback.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExitSlipController : ControllerBase
    {
        private readonly IExitSlipQuery _exitSlipQuery;

        public ExitSlipController(IExitSlipQuery exitSlipQuery)
        {
            this._exitSlipQuery = exitSlipQuery;
        }

        // GET: api/<ExitSlipController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ExitSlipController>/5
        [HttpGet("{id}")]
        public Question Get(Guid id)
        {
            var dto = this._exitSlipQuery.GetAll().First().QuestionList.FirstOrDefault(a => a.Id == id);

            return dto;
        }

        // POST api/<ExitSlipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExitSlipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExitSlipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
