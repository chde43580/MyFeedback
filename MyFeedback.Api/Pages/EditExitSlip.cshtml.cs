using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Application.Command;
using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;

namespace MyFeedback.Api.Pages
{
    public class EditExitSlipModel : PageModel
    {

        private readonly IExitSlipQuery _exitSlipQuery;

        private readonly IExitSlipCommand _exitSlipCommand;

        public EditExitSlipModel(IExitSlipQuery exitSlipQuery, IExitSlipCommand exitSlipCommand)
        {
            this._exitSlipQuery = exitSlipQuery;   

            this._exitSlipCommand = exitSlipCommand;
        }

        [BindProperty]
        public ExitSlipDto ExitSlipDto { get; set; }

        [BindProperty]
        public bool IsChecked { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.ExitSlipDto = _exitSlipQuery.Get(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            UpdateExitSlipDto updateExitSlipDto = new UpdateExitSlipDto();

            updateExitSlipDto.Id = ExitSlipDto.Id;
            updateExitSlipDto.RowVersion = ExitSlipDto.RowVersion;
            updateExitSlipDto.LessonId = ExitSlipDto.LessonId;
            updateExitSlipDto.QuestionList = ExitSlipDto.QuestionList;

            if (ExitSlipDto.IsPublished == false)
            {
                updateExitSlipDto.IsPublished = IsChecked;
            }
            else
            {
                updateExitSlipDto.IsPublished = ExitSlipDto.IsPublished;
            }


           this._exitSlipCommand.UpdateExitSlip(updateExitSlipDto);

            if (User.HasClaim("IsTeacher", "1"))
            {
                return RedirectToPage("TeacherExitSlipStartPage");
            }

            else if (User.HasClaim("IsStudent", "1"))
            {
                return RedirectToPage("StudentExitSlipStartPage");
            }
            else {
                return Page();
                }
        }
    }
}
