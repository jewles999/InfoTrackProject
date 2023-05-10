using InfoTrack.Application.Contracts.Infrastructure;

namespace InfoTrack.Infrastructure
{
    public class NotifierService : INotifier
    {
        public async Task NotifyTechSupport(string pattern)
        {
            //send notification to tech support
            await Task.Run(() => Console.WriteLine($"Google changed page source. Element {pattern} cannot be found"));
        }
    }
}
