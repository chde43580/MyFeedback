using MyFeedback.Application.Query.QueryDto;
using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query
{
    public interface ICategoryQuery
    {
        IEnumerable<CategoryDto> GetAll();

        CategoryDto Get(Guid id);
    }
}
