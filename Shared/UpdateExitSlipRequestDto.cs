using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record UpdateExitSlipRequestDto
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Guid LessonId { get; set; }

    //    public List<MyFeedback.Domain.Entities.Question> QuestionList { get; set; } Skal selvf. blive til et Dto

        public bool IsPublished { get; set; }
    }
}
