﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Query.QueryDto
{
    public record PastCommentQueryDto
    {
        public Guid Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
