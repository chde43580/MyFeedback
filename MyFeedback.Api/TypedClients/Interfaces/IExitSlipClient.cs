
using MyFeedback.Api.Pages.Model;
using MyFeedback.Application.Query.QueryDto;
using Shared;

namespace MyFeedback.Api.TypedClients.Interfaces
{
    public interface IExitSlipClient
    {
        public Task<ExitSlipResultDto> GetExitSlip(Guid? id);

        public Task<string> CreateExitSlip(CreateExitSlipRequestDto createExitSlipRequestDto);

        public Task<string> UpdateExitSlip(ExitSlipViewModel exitSlipDto);
    }
}
