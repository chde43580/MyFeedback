using Microsoft.AspNetCore.Mvc;
using MyFeedback.Application.Command;
using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Command.CommandDto.Question;
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

        private readonly IExitSlipCommand _exitSlipCommand;
 

        public ExitSlipController(IExitSlipQuery exitSlipQuery, IExitSlipCommand exitSlipCommand)
        {
            _exitSlipQuery = exitSlipQuery;

            _exitSlipCommand = exitSlipCommand;
        }

        // GET ALL: <ExitSlipController>
        [HttpGet]
        public IEnumerable<ExitSlipQueryDto> GetAll()
        {
            IEnumerable<ExitSlipQueryDto> exitSlipQueryDtos = _exitSlipQuery.GetAll();

            return exitSlipQueryDtos;
        }

        // GET <ExitSlipController>/aiojwdioja92929-92j92-29dj9j-2929ks    EKSEMPEL PÅ ET ID GUID

        [HttpGet("{id}")]
        public ExitSlipQueryDto Get(Guid id)
        {


            ExitSlipQueryDto queryResult = _exitSlipQuery.Get(id);

            return queryResult;
           
        }

        // POST <ExitSlipController>
        [HttpPost]
        public void Post(CreateExitSlipRequestDto createExitSlipRequestDto)
        {
            CreateExitSlipDto createExitSlipDto = new CreateExitSlipDto()
                { QuestionList = new List<CreateQuestionDto>(), IsPublished = createExitSlipRequestDto.IsPublished, LessonId = createExitSlipRequestDto.LessonId};

            foreach (var question in createExitSlipRequestDto.QuestionList)
            {
                createExitSlipDto.QuestionList.Add(new CreateQuestionDto { QuestionNumber = question.QuestionNumber, QuestionText = question.QuestionText });
            }

            _exitSlipCommand.CreateExitSlip(createExitSlipDto);
        }

        // PUT <ExitSlipController>
        [HttpPut]
        public void UpdateExitSlip(UpdateExitSlipRequestDto dto)
        {

        }


        // DELETE <ExitSlipController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var queryDto = _exitSlipQuery.Get(id);

           DeleteExitSlipDto deleteCommandDto = new DeleteExitSlipDto { Id = queryDto.Id, RowVersion = queryDto.RowVersion };

            _exitSlipCommand.DeleteExitSlip(deleteCommandDto);
        }
    }
}
