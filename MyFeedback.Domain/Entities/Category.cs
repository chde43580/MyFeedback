using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class Category : DomainEntity
    {
        public string Name { get; protected set; }
    }
}
