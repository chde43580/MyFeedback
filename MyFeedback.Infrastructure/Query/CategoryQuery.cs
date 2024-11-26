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
    public class CategoryQuery : ICategoryQuery
    {
        private readonly MyFeedbackContext _dbContext;

        public CategoryQuery(MyFeedbackContext dbContext)
        {
            _dbContext = dbContext;
        }

        CategoryDto ICategoryQuery.Get(Guid id)
        {
            Category domainCategory = _dbContext.Categories.AsNoTracking().Single(e => e.Id == id);

            CategoryDto dtoToReturn = new CategoryDto
            {
                Id = domainCategory.Id,
                Name = domainCategory.Name,
                RowVersion = domainCategory.RowVersion,
            };

            return dtoToReturn;
        }

        IEnumerable<CategoryDto> ICategoryQuery.GetAll()
        {
            var listOfDtos = _dbContext.Categories.AsNoTracking().Select(e => new CategoryDto()
            {
                Id = e.Id,
                Name = e.Name,
                RowVersion = e.RowVersion,
            });    
            
            return listOfDtos;
        }
    }
}
