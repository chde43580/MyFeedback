using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Api.Pages.Model;
using MyFeedback.Api.TypedClients.Interfaces;
using Shared;

namespace MyFeedback.Api.Pages
{
    public class EditExitSlipModel : PageModel
    {
        private readonly IExitSlipClient _exitSlipClient;

        public EditExitSlipModel(IExitSlipClient exitSlipClient)
        {
            this._exitSlipClient = exitSlipClient;
        }

        [BindProperty]
        public ExitSlipViewModel ExitSlipViewModel { get; set; }

        [BindProperty]
        public bool IsChecked { get; set; }

        public async Task<IActionResult> OnGet(Guid? id)
        {
            if (id == null) // Hvis man har navigeret til denne side UDEN / MED ET TOMT id-parameter i URL'en, skal man blot sendes til en NotFound-side
            {
                return NotFound();
            }
            else
            {


               ExitSlipResultDto resultDto = await _exitSlipClient.GetExitSlip(id); // Her kunne man evt. køre noget validering på id-variablen fra URL'et; for hvad hvis brugeren inputter et ugyldigt id

                ExitSlipViewModel = new ExitSlipViewModel
                {
                    Id = resultDto.Id,
                    LessonId = resultDto.LessonId,
                    IsPublished = resultDto.IsPublished,
                    RowVersion = resultDto.RowVersion,
                    QuestionList = resultDto.QuestionList
                };

               
              

                return Page();
            }
        }

        public IActionResult OnPost()
        {
         //   Request.Form("CreateQuestionRequestDto");

             ExitSlipViewModel.QuestionList.Add(CreateQuestionRequestDto);
            
           

            var testMeAsWell = Request.Form;


            return Page();

           // _exitSlipClient.UpdateExitSlip(ExitSlipDto);

           // UpdateExitSlipDto updateExitSlipDto = new UpdateExitSlipDto();

           // updateExitSlipDto.Id = ExitSlipDto.Id;
           // updateExitSlipDto.RowVersion = ExitSlipDto.RowVersion;
           // updateExitSlipDto.LessonId = ExitSlipDto.LessonId;
           // updateExitSlipDto.QuestionList = ExitSlipDto.QuestionList;

           // if (ExitSlipDto.IsPublished == false)
           // {
           //     updateExitSlipDto.IsPublished = IsChecked;
           // }
           // else
           // {
           //     updateExitSlipDto.IsPublished = ExitSlipDto.IsPublished; // I dette tilfælde tilsvarer dette altid, at sætte updateDto'ens IsPublished til true
           // }


           //this._exitSlipCommand.UpdateExitSlip(updateExitSlipDto);

           // if (User.HasClaim("IsTeacher", "1"))
           // {
           //     return RedirectToPage("TeacherExitSlipStartPage"); // Underviseren ønsker nok komme tilbage til sin exit slip-startside, så de kan få vist deres nyopdaterede exit slip
           // }

           // else if (User.HasClaim("IsStudent", "1"))
           // {
           //     return RedirectToPage("StudentForumStartpage"); // PO ønskede man som studerende skulle sendes tilbage til deres forums startside
           // }

           // else 
           // {
           //     return Page();
           // }
        }
    }
}
