
using MyFeedback.Frontend.Pages.Model;
using MyFeedback.Application.Query.QueryDto;
using Shared;

namespace MyFeedback.Frontend.TypedClients.Interfaces
{
    public interface IExitSlipClient
    {
        public Task<ExitSlipResultDto> GetExitSlip(Guid? id);

        public Task<List<ExitSlipResultDto>> GetAllExitSlips();

        public Task<string> CreateExitSlip(CreateExitSlipRequestDto createExitSlipRequestDto);

        public Task<string> UpdateExitSlip(ExitSlipViewModel exitSlipDto);

        public Task DeleteExitSlip(Guid id);
    }
}
