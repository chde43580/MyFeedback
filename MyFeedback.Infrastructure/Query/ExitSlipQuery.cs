using Microsoft.EntityFrameworkCore;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Query
{
    public class ExitSlipQuery : IExitSlipQuery
    {
        private readonly MyFeedbackContext _dbContext;

         public ExitSlipQuery(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        IEnumerable<ExitSlipDto> IExitSlipQuery.GetAll()
        {
         
            var listOfDtos = _dbContext.ExitSlips.AsNoTracking().Select(e => new ExitSlipDto
            {
                Id = e.Id,
                LessonId = e.LessonId,
                QuestionList = e.QuestionList,
                RowVersion = e.RowVersion,
            });

             

            return listOfDtos;
        }
    }
}
