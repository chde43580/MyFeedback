using MyFeedback.Api.Pages.Model;
using MyFeedback.Api.TypedClients.Interfaces;
using MyFeedback.Application.Query.QueryDto;
using Shared;

namespace MyFeedback.Api.TypedClients.Implementations
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

        async Task<ExitSlipResultDto> IExitSlipClient.GetExitSlip(Guid? id) // TODO: Må vi godt bruge vores queryDto her? Eller er det bedre at oprette en resultDto og lægge dén i Shared-class librariet?
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

        //public async Task<string> Get(Guid? id)
        //{

        //    var getResponse = await _client.GetAsync($"MyFeedbackBaseUrl/ExitSlip?id={id}");

        //    getResponse.EnsureSuccessStatusCode();

        //    return await getResponse.Content.ReadAsStringAsync();
        //}

        //async Task<string> IExitSlipClient.Post(HttpRequest postRequest)
        //{
        //    var postResponse = await _client.PostAsync("postExitSlip");

        //    postResponse.EnsureSuccessStatusCode();

        //    return await postResponse.Content.ReadAsStringAsync();
        //}
    }
}
