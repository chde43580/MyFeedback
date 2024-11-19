using MyFeedback.Application.Command.CommandDto;
using MyFeedback.Application.Repositories;
using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Repositories
{
    public class ExitSlipRepo : IExitSlipRepo
    {
        private readonly MyFeedbackContext _dbContext;

        public ExitSlipRepo(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        void IExitSlipRepo.AddExitSlip(ExitSlip exitSlip)
        {
            _dbContext.ExitSlips.Add(exitSlip);

            _dbContext.SaveChanges();
        }

        void IExitSlipRepo.AddExitSlipDto(CreateExitSlipDto exitSlipDto)
        {
            // Her konverteres fra DTO til domæne-entitet - måske bare midlertidigt?

         

            var exitSlip = new ExitSlip{
                LessonId = exitSlipDto.LessonId,
                QuestionList = new List<Question>()
            };

            foreach (var questionDto in exitSlipDto.QuestionList)
            {
                Question tempQuestion = new Question(questionDto.QuestionNumber, questionDto.QuestionText);

                exitSlip.QuestionList.Add(tempQuestion);
            }

            _dbContext.ExitSlips.Add(exitSlip);

            _dbContext.SaveChanges();
        }

        void IExitSlipRepo.DeleteExitSlip(ExitSlip exitSlip, byte[] rowVersion)
        {
            _dbContext.Entry(exitSlip).Property(nameof(exitSlip.RowVersion)).OriginalValue = rowVersion;

            _dbContext.ExitSlips.Remove(exitSlip);

            _dbContext.SaveChanges();
        }

        ExitSlip IExitSlipRepo.GetExitSlip(Guid id)
        {
            return _dbContext.ExitSlips.Single(b => b.Id == id);
        }

        void IExitSlipRepo.UpdateExitSlip(ExitSlip exitSlip, byte[] rowVersion)
        {
            _dbContext.Entry(exitSlip).Property(nameof(exitSlip.RowVersion)).OriginalValue = rowVersion;

            _dbContext.ExitSlips.Update(exitSlip); // Virker det her??

            _dbContext.SaveChanges();
        }
    }
}
