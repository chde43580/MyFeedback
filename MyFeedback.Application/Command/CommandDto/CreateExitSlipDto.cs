using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command.CommandDto
{
    public record CreateExitSlipDto
    {
        public Guid LessonId { get; set; }

        public List<CreateQuestionDto> QuestionList { get; set; } = null!;

        //public CreateExitSlipDto(Guid lessonId, List<Question> questionList)
        //{
        //    this.LessonId = lessonId;
        //    this.QuestionList = questionList;
        //}
    }
}
