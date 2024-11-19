using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Answer : DomainEntity
    {
        public Guid QuestionId { get; protected set; }
        public Guid IdentityUserId { get; protected set; }
        public string AnswerText { get; protected set; }
    }
}
