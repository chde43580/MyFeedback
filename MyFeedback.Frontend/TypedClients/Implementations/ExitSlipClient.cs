using MyFeedback.Frontend.Pages.Model;
using MyFeedback.Frontend.TypedClients.Interfaces;
using MyFeedback.Application.Query.QueryDto;
using Shared;

namespace MyFeedback.Frontend.TypedClients.Implementations
{
    public class ExitSlipClient : IExitSlipClient
    {
        private readonly HttpClient _client;
        public ExitSlipClient(HttpClient client)
        {
            _client = client;
        }

        Task<string> IExitSlipClient.CreateExitSlip(CreateExitSlipRequestDto createExitSlipRequestDto)
        {
            throw new NotImplementedException();
        }

        async Task IExitSlipClient.DeleteExitSlip(Guid id)
        {
            await _client.DeleteAsync($"/ExitSlip/{id}");
        }

        async Task<List<ExitSlipResultDto>> IExitSlipClient.GetAllExitSlips()
        {
            return await _client.GetFromJsonAsync<List<ExitSlipResultDto>>("/ExitSlip");
        }

        async Task<ExitSlipResultDto> IExitSlipClient.GetExitSlip(Guid? id) 
        {
            return await _client.GetFromJsonAsync<ExitSlipResultDto>($"/ExitSlip/{id}");

            // getResponse.EnsureSuccessStatusCode();
        }

       

        async Task<string> IExitSlipClient.UpdateExitSlip(ExitSlipViewModel exitSlipViewModel)
        {
            var updateExitSlipRequestDto = new UpdateExitSlipRequestDto { Id = exitSlipViewModel.Id, IsPublished = exitSlipViewModel.IsPublished, LessonId = exitSlipViewModel.LessonId, RowVersion = exitSlipViewModel.RowVersion };

            var postResponse = await _client.PutAsJsonAsync<UpdateExitSlipRequestDto>("ExitSlip", updateExitSlipRequestDto);

            postResponse.EnsureSuccessStatusCode();

            return await postResponse.Content.ReadAsStringAsync();
        }
    }
}
