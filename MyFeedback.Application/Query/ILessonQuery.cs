﻿using MyFeedback.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query
{
    public interface ILessonQuery
    {
        IEnumerable<LessonDto> GetAll();

        LessonDto Get(Guid? id);
    }
}
