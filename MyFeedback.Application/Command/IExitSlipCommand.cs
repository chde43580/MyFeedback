using MyFeedback.Application.Command.CommandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command
{
    public interface IExitSlipCommand
    {
        void CreateExitSlip(CreateExitSlipDto createExitSlipDto);
    }
}
