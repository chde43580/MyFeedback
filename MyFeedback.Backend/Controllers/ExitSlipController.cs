using Microsoft.AspNetCore.Mvc;

using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using MyFeedback.Domain.Entities;
using MyFeedback.Infrastructure.TypedClients.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFeedback.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExitSlipController : ControllerBase
    {
        private readonly IExitSlipQuery _exitSlipQuery;

        private readonly ExitSlipClient _exitSlipClient;

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
        public ExitSlipDto Get(Guid id)
        {


            var queryResult = _exitSlipQuery.Get(id);

            return queryResult;
           
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
