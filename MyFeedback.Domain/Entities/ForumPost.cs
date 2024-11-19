using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class ForumPost : DomainEntity
    {
        public DateTime PostDate { get; protected set; }
        public List<Comment> Comments { get; protected set; }
        public Guid CategoryId { get; protected set; }
        public string ProblemText { get; protected set; }
        public string SolutionText { get; protected set; }
        public int UpVotes { get; protected set; }
        public int DownVotes { get; protected set; }
        public int TimesReported { get; protected set; }
        public bool IsLocked { get; protected set; }
    }
}
