using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Api.TypedClients.Interfaces;
using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Command.CommandDto.Question;
using MyFeedback.Application.Query.QueryDto;
using Shared;

namespace MyFeedback.Api.Pages
{
    [Authorize("IsLoggedIn")]
    public class ExitSlipModel : PageModel
    {


        private readonly IExitSlipClient _exitSlipClient;



        [BindProperty]
        public CreateExitSlipRequestDto createExitSlipRequestDto { get; set; }

        [BindProperty]
        public ExitSlipQueryDto exitSlipDto { get; set; }


        public ExitSlipModel(IExitSlipClient exitSlipClient)
        {

            this._exitSlipClient = exitSlipClient;

        }

        public void OnGet(Guid? id)
        {
            //   var exitSlipDto = this._exitSlipController.Get(id);

            //    ExitSlipClient exitSlipClient = new ExitSlipClient();

            //    var jsonResponse = exitSlipClient.Get(id);


            // Skal guid måske være nullable

            //      this.exitSlipDto.
        }

        public void OnPost()
        {
            CreateExitSlipRequestDto createExitSlipRequestDto = new CreateExitSlipRequestDto();

            createExitSlipRequestDto.QuestionList = new List<CreateQuestionRequestDto>();

            for (int i = 1; i < 6; i++)
            {


                if (Request.Form[$"question{i}Text"] == "")
                {
                    // Does nothing
                }
                else
                {
                    CreateQuestionRequestDto questionDto = new CreateQuestionRequestDto();

                    questionDto.QuestionText = Request.Form[$"question{i}Text"];
                    questionDto.QuestionNumber = i;
                    createExitSlipRequestDto.QuestionList.Add(questionDto);
                }
            }

            createExitSlipRequestDto.LessonId = new Guid(); // NEEDS TO BE THE ACTUAL LESSON ID LATER ON

            //  _exitSlipRepo.AddExitSlipDto(createExitSlipDto);

            _exitSlipClient.CreateExitSlip(createExitSlipRequestDto);

            //   return RedirectToPage?

        }
    }
}
