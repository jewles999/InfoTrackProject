namespace InfoTrack.Application.Contracts.Infrastructure
{
    public interface INotifier
    {
        public Task NotifyTechSupport(string pattern);
    }
}
