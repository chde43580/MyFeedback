using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Application.Command.CommandDto;
using MyFeedback.Application.Repositories;

namespace MyFeedback.Api.Pages
{
    public class ExitSlipModel : PageModel
    {
        private readonly IExitSlipRepo _exitSlipRepo;

        //[BindProperty]
        //public CreateExitSlipDto createExitSlipDto { get; set; }

        [BindProperty]
        public CreateQuestionDto questionDto { get; set; }



        public ExitSlipModel(IExitSlipRepo exitSlipRepo)
        {
            this._exitSlipRepo = exitSlipRepo;
        }

        public void OnGet()
        {
        }

        public void OnPost() 
        {
            CreateExitSlipDto createExitSlipDto = new CreateExitSlipDto();

            createExitSlipDto.QuestionList = new List<CreateQuestionDto>();

            for (int i = 1; i < 6; i++)
            {
             

                if (Request.Form[$"question{i}Text"] == "")
                {
                  // Does nothing
                }
                else
                {
                    CreateQuestionDto questionDto = new CreateQuestionDto();

                    questionDto.QuestionText = Request.Form[$"question{i}Text"];
                    questionDto.QuestionNumber = i;
                    createExitSlipDto.QuestionList.Add(questionDto);
                }
            }

            createExitSlipDto.LessonId = new Guid(); // NEEDS TO BE THE ACTUAL LESSON ID LATER ON
   
          _exitSlipRepo.AddExitSlipDto(createExitSlipDto);

         //   return RedirectToPage?

        }
    }
}
