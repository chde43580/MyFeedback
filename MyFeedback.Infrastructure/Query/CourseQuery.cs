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
    public class CourseQuery : ICourseQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public CourseQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        CourseDto ICourseQuery.Get(Guid? id)
        {
            Course domainCourse = _dbContext.Courses.AsNoTracking().Include(e => e.StudentClassIds).Single(e => e.Id == id);

            CourseDto dtoReturn = new CourseDto()
            {
                Id = domainCourse.Id,
                Name = domainCourse.Name,
                StudentClassIds = domainCourse.StudentClassIds,
                StartDate = domainCourse.StartDate,
                EndDate = domainCourse.EndDate,
                SchoolId = domainCourse.SchoolId,
                RowVersion = domainCourse.RowVersion,
            };

            return dtoReturn;
        }

        IEnumerable<CourseDto> ICourseQuery.GetAll()
        {
            var listOfDtos = _dbContext.Courses.AsNoTracking().Select(e => new CourseDto
            {
                Id = e.Id,
                Name = e.Name,
                StudentClassIds = e.StudentClassIds,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                SchoolId= e.SchoolId,
                RowVersion = e.RowVersion,
            });

            return listOfDtos;
        }
    }
}
