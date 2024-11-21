﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedback.Domain.Entities;

namespace MyFeedback.Application.Command.CommandDto.ExitSlip
{
    public record UpdateExitSlipDto
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Guid LessonId { get; set; }

        public List<MyFeedback.Domain.Entities.Question> QuestionList { get; set; }
    }
}
