using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Course : DomainEntity
    {
        public string Name { get; protected set; }
        public List<Guid> StudentClassIds { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }

        public Guid SchoolId { get; protected set; }
    }
}
