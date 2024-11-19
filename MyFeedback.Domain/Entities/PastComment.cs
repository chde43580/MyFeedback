using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class PastComment : DomainEntity
    {
        public string CommentText { get; protected set; }
        public DateTime CommentDate { get; protected set; }
    }
}
