using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Comment : DomainEntity
    {
        public string CommentText { get; protected set; }
        public DateTime CommentDate { get; protected set; }
        public List<PastComment> PastComments { get; protected set; }
        public Guid IdentityUserId { get; protected set; }
    }
}
