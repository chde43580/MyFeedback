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
            if (createExitSlipRequestDto == null)
            {
                createExitSlipRequestDto = new CreateExitSlipRequestDto();

                createExitSlipRequestDto.QuestionList = new List<CreateQuestionRequestDto>();

                createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto() {QuestionNumber = 1, QuestionText = ""});
            }
        }

        public IActionResult OnPostCreateExitSlip()
        {

        //    createExitSlipRequestDto.LessonId = new Guid(); // NEEDS TO BE THE ACTUAL LESSON ID LATER ON

          

            _exitSlipClient.CreateExitSlip(createExitSlipRequestDto);

            return RedirectToPage("TeacherExitSlipStartPage");

        }

        public IActionResult OnPostAddQuestion()
        {
            createExitSlipRequestDto.QuestionList.Add(new CreateQuestionRequestDto());

            return Page();
        }
    }
}
