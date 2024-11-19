using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Question : DomainEntity
    {
        public Question(int questionNumber, string questionText)
        {
            QuestionNumber = questionNumber;   
            QuestionText = questionText;
        }

        public int QuestionNumber { get; protected set; }
        public string QuestionText { get; protected set; }
        public List<Answer> Answers { get; protected set; }

        public Question Create(int questionNumber, string questionText)
        {
            Question newQuestion = new Question(questionNumber, questionText);

            return newQuestion;
        }

      //  public Question Update
    }
}
