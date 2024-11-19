using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class ExitSlip : DomainEntity
    {
        public ExitSlip() 
        { 
        }

        public ExitSlip(Guid lessonId, List<Question> questionList)
        {
            this.LessonId = lessonId;
            this.QuestionList = questionList;
        }

        public Guid LessonId { get; set; } // Should maybe be protected setting?
        public List<Question> QuestionList { get; set; } // Same as above

        public static ExitSlip Create(Guid lessonId, List<Question> questionList)
        {
            ExitSlip newExitSlip = new ExitSlip(lessonId, questionList);

            return newExitSlip;
        }
    }
}
