using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record ExitSlipResultDto
    {
        public Guid Id { get; set; }

        public Guid LessonId { get; set; }

        public List<CreateQuestionRequestDto> QuestionList { get; set; } // TODO: Skal vi senere uddifferentiere til en anden slags QuestionDto end som her (requestdto)

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool IsPublished { get; set; }
    }
}
