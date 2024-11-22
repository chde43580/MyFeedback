namespace MyFeedback.Backend.TypedClients.Interfaces
{
    public interface IExitSlipClient
    {
        public Task<string> Get(Guid? id);
    }
}
