using Microsoft.EntityFrameworkCore;
using MyFeedback.Application.Query;
using MyFeedback.Application.Query.QueryDto;
using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure.Query
{
    public class LessonQuery : ILessonQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public LessonQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        LessonDto ILessonQuery.Get(Guid? id)
        {
            Lesson domainLesson = _dbContext.Lessons.AsNoTracking().Single(e => e.Id == id);

            LessonDto dtoReturn = new LessonDto
            {
                Id = domainLesson.Id,
                StartDate = domainLesson.StartDate,
                CourseId = domainLesson.CourseId,
                RowVersion = domainLesson.RowVersion,
            };

            return dtoReturn;
        }

        IEnumerable<LessonDto> ILessonQuery.GetAll()
        {
            var listOfDtos = _dbContext.Lessons.AsNoTracking().Select(e => new LessonDto
            {
                Id = e.Id,
                StartDate = e.StartDate,
                CourseId = e.CourseId,
                RowVersion = e.RowVersion,
            });

            return listOfDtos;
        }
    }
}
