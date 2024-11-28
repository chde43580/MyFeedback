using Microsoft.AspNetCore.Mvc;

using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFeedback.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExitSlipController : ControllerBase
    {
     
        private readonly IExitSlipQuery _exitSlipQuery;
 

        public ExitSlipController(IExitSlipQuery exitSlipQuery)
        {
            _exitSlipQuery = exitSlipQuery;
        }

        // GET ALL: <ExitSlipController>
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET <ExitSlipController>/aiojwdioja92929-92j92-29dj9j-2929ks    EKSEMPEL PÅ ET ID GUID

        [HttpGet("{id}")]
        public ExitSlipQueryDto Get(Guid id)
        {


            var queryResult = _exitSlipQuery.Get(id); // TODO: Spørg Kaj om dette lag godt må kende Application-laget (så det kan få fat i Query, etc.) (LevSundt gør det)

            return queryResult;
           
        }

        // POST <ExitSlipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <ExitSlipController>
        [HttpPut]
        public void UpdateExitSlip(UpdateExitSlipRequestDto dto)
        {

        }


        // DELETE <ExitSlipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
