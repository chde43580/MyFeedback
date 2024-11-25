using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Application.Command;
using MyFeedback.Application.Command.CommandDto.ExitSlip;
using MyFeedback.Application.Command.CommandDto.Question;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using MyFeedback.Application.Repositories;
using MyFeedback.Backend.Controllers;
using MyFeedback.Backend.TypedClients.Interfaces;
using System.Configuration;

namespace MyFeedback.Api.Pages
{
    [Authorize("IsLoggedIn")]
    public class ExitSlipModel : PageModel
    {

        private readonly IExitSlipCommand _exitSlipCommand;

        private readonly IExitSlipQuery _exitSlipQuery;

        private readonly IExitSlipClient _exitSlipClient;

        //   private readonly ExitSlipController _exitSlipController;



        [BindProperty]
        public CreateExitSlipDto createExitSlipDto { get; set; }

        [BindProperty]
        public ExitSlipDto exitSlipDto { get; set; }


        public ExitSlipModel(IExitSlipCommand exitSlipCommand, IExitSlipQuery exitSlipQuery, IExitSlipClient exitSlipClient /*, ExitSlipController exitSlipController */)
        {

            this._exitSlipCommand = exitSlipCommand;

            this._exitSlipQuery = exitSlipQuery;

            this._exitSlipClient = exitSlipClient;

            //     this._exitSlipController = exitSlipController;


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
