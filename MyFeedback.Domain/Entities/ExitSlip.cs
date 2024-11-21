using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class ExitSlip : DomainEntity
    {
        public Guid LessonId { get; set; } // Should maybe be protected setting?
        public List<Question> QuestionList { get; set; } // Same as above

        public bool IsPublished { get; set; }

        public ExitSlip() 
        { 
        }

        public ExitSlip(Guid lessonId, List<Question> questionList, bool isPublished)
        {
            this.LessonId = lessonId;
            this.QuestionList = questionList;
            this.IsPublished = isPublished;
        }

        

        public static ExitSlip Create(Guid lessonId, List<Question> questionList, bool isPublished)
        {
            ExitSlip newExitSlip = new ExitSlip(lessonId, questionList, isPublished);

            return newExitSlip;
        }

    //    public 
    }
}
