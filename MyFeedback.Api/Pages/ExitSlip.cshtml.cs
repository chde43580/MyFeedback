using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Application.Command;
using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Command.CommandDto.Question;
using MyFeedback.Application.Query;
using MyFeedback.Application.Repositories;

namespace MyFeedback.Api.Pages
{
    [Authorize("IsTeacher")]
    public class ExitSlipModel : PageModel
    {
     //   private readonly IExitSlipRepo _exitSlipRepo;

        private readonly IExitSlipCommand _exitSlipCommand;

        private readonly IExitSlipQuery _exitSlipQuery;

        //[BindProperty]
        //public CreateExitSlipDto createExitSlipDto { get; set; }

        [BindProperty]
        public CreateQuestionDto questionDto { get; set; }

       



        public ExitSlipModel(IExitSlipCommand exitSlipCommand, IExitSlipQuery exitSlipQuery/*, IExitSlipRepo exitSlipRepo*/)
        {
       //     this._exitSlipRepo = exitSlipRepo;

            this._exitSlipCommand = exitSlipCommand;

            this._exitSlipQuery = exitSlipQuery;
        }

        public void OnGet()
        {
            // Flyttes til index

          //  ExitSlipQueryResult slips = _exitSlipQuery.Get(Guid id);
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
   
        //  _exitSlipRepo.AddExitSlipDto(createExitSlipDto);

            _exitSlipCommand.CreateExitSlip(createExitSlipDto);

         //   return RedirectToPage?

        }
    }
}
