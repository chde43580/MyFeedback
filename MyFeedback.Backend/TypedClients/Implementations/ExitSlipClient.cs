using Azure;
using Microsoft.VisualBasic;
using MyFeedback.Domain.Entities;
using MyFeedback.Backend.TypedClients.Interfaces;

namespace MyFeedback.Backend.TypedClients.Implementations
{
    public class ExitSlipClient : IExitSlipClient
    {
        private readonly HttpClient _client;
        public ExitSlipClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> Get(Guid? id)
        {

            //var response = await _client.GetAsync();

            // response.EnsureSuccessStatusCode();

            // return await response.Content.ReadAsStringAsync();

            //   return await _client.GetStringAsync()

            return "hej";
        }
    }
}
