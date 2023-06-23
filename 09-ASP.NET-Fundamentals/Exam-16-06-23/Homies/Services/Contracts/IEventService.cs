using Homies.Models.EventModels;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        public Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync();

        public Task<IEnumerable<AllEventsViewModel>> GetAllJoinedEventsAsync(string userId);
    }
}
