using Homies.Models.EventModels;
using Homies.Models.TypeModels;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        public Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync();

        public Task<IEnumerable<AllEventsViewModel>> GetAllJoinedEventsAsync(string userId);

        public Task<IEnumerable<TypeViewModel>> GetTypesAsync();

        public Task AddNewEventAsync(AddEventViewModel newEvent);

        public Task<EditEventViewModel?> GetEventByIdAsync(int id);

        public Task EditEventAsync(int id, EditEventViewModel eventModel);

        public Task AddToJoinedEventsAsync(string userId, int id);

        public Task RemoveFromJoinedEventsAsync(string userId, int id);

        public Task<DetailsEventViewModel?> GetDetailsEventByIdAsync(int id);
    }
}
