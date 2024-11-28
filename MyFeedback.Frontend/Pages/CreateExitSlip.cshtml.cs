using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Frontend.TypedClients.Interfaces;
using Shared;

namespace MyFeedback.Frontend.Pages
{
    [Authorize("IsLoggedIn")]
    public class ExitSlipModel : PageModel
    {


        private readonly IExitSlipClient _exitSlipClient;



        [BindProperty]
        public CreateExitSlipRequestDto createExitSlipRequestDto { get; set; }


        public ExitSlipModel(IExitSlipClient exitSlipClient)
        {

            this._exitSlipClient = exitSlipClient;

        }

        public void OnGet()
        {
         createExitSlipRequestDto = new CreateExitSlipRequestDto { QuestionList = new List<CreateQuestionRequestDto>()};

            createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto { QuestionNumber = 1, QuestionText = "" });
            createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto { QuestionNumber = 2, QuestionText = "" });
            createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto { QuestionNumber = 3, QuestionText = "" });
            createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto { QuestionNumber = 4, QuestionText = "" });
            createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto { QuestionNumber = 5, QuestionText = "" });
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
