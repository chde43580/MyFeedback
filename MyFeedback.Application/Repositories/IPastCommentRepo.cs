﻿using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Repositories
{
    public interface IPastCommentRepo
    {
        void AddPastComment(PastComment pastcomment);
    }
}
