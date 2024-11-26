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
    public class StudentClassQuery : IStudentClassQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public StudentClassQuery(MyFeedbackContext dbContext)
        {
            this._dbContext = dbContext;
        }

        IEnumerable<StudentClassDto> IStudentClassQuery.GetAll()
        {

            var listOfDtos = _dbContext.StudentClasses.AsNoTracking().Select(e => new StudentClassDto
            {
                Id = e.Id,
                Name = e.Name,
                StudentIds = e.StudentIds,
                RowVersion = e.RowVersion,
                GraduationDate = e.GraduationDate,
                CourseId = e.CourseId,
            });

            return listOfDtos;
        }

        StudentClassDto IStudentClassQuery.Get(Guid? id)
        {
            StudentClass domainStudentClass = _dbContext.StudentClasses.AsNoTracking().Include(e => e.StudentIds).Single(e => e.Id == id);

            StudentClassDto dtoToReturn = new StudentClassDto
            {
                Id = domainStudentClass.Id,
                Name = domainStudentClass.Name,
                StudentIds = domainStudentClass.StudentIds,
                RowVersion = domainStudentClass.RowVersion,
                GraduationDate = domainStudentClass.GraduationDate,
                CourseId = domainStudentClass.CourseId,
            };

            return dtoToReturn;
        }       
    }
}
