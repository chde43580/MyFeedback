using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;

namespace MyFeedback.Api.Pages
{

    [Authorize("IsLoggedIn")]
    public class TeacherExitSlipStartPageModel : PageModel
    {
        private readonly IExitSlipQuery _exitSlipQuery;

        public IEnumerable<ExitSlipQueryDto> ExitSlipDtoList { get; set; }

        public TeacherExitSlipStartPageModel(IExitSlipQuery exitSlipQuery)
        {
            this._exitSlipQuery = exitSlipQuery;
        }

        public IActionResult OnGet()
        {
            if (User.HasClaim("IsStudent", "1"))
            {
                return RedirectToPage("/StudentExitSlipStartPage");
            }

          ExitSlipDtoList = _exitSlipQuery.GetAll();



            return null;

        }
    }
}
