using MyFeedback.Application.Command.CommandDto;
using MyFeedback.Application.Repositories;
using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command
{
    public class ExitSlipCommand : IExitSlipCommand
    {
        private readonly IExitSlipRepo _exitSlipRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ExitSlipCommand(IExitSlipRepo exitSlipRepo, IUnitOfWork unitOfWork)
        {
            this._exitSlipRepo = exitSlipRepo;
            this._unitOfWork = unitOfWork;
        }


        void IExitSlipCommand.CreateExitSlip(CreateExitSlipDto createExitSlipDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                ExitSlip newExitSlip = ExitSlip.Create(createExitSlipDto.LessonId, new List<Question>());

                foreach (var questionDto in createExitSlipDto.QuestionList)
                {
                    Question tempQuestion = new Question(questionDto.QuestionNumber, questionDto.QuestionText);

                    newExitSlip.QuestionList.Add(tempQuestion);
                }

                

                _exitSlipRepo.AddExitSlip(newExitSlip);

                _unitOfWork.Commit();
            }
            catch (Exception ex) 
            {
                _unitOfWork.Rollback();

                throw(ex);

            }
            
        }
    }
}
