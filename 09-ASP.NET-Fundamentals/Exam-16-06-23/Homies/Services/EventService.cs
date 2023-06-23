using Homies.Data;
using Homies.Data.Models;
using Homies.Models.EventModels;
using Homies.Models.TypeModels;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync()
        {
            var allEvents = await dbContext
                .Events
                .Select(e => new AllEventsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();

            return allEvents;
        }

        public async Task<IEnumerable<AllEventsViewModel>> GetAllJoinedEventsAsync(string userId)
        {
            var joinedEvents = await dbContext
                .EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new AllEventsViewModel
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start,
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName
                })
                .ToListAsync();

            return joinedEvents;
        }

        public async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
        {
            var types = await dbContext
                .Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            return types;
        }

        public async Task AddNewEventAsync(AddEventViewModel newEvent)
        {
            var currType = await dbContext
                .Types
                .Where(t => t.Id == newEvent.TypeId)
                .FirstOrDefaultAsync();


            var addEvent = new Event()
            {
                Name = newEvent.Name,
                Description = newEvent.Description,
                Start = newEvent.Start,
                End = newEvent.End,
                TypeId = newEvent.TypeId,
                Type = currType!,
                OrganiserId = newEvent.OrganiserId,
                CreateOn = DateTime.UtcNow
            };

            await dbContext.Events.AddAsync(addEvent);
            await dbContext.SaveChangesAsync();

        }

        public async Task<EditEventViewModel?> GetEventByIdAsync(int id)
        {
            var types = await dbContext
                .Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            EditEventViewModel? currEvent = await dbContext
                .Events
                .Where(e => e.Id == id)
                .Select(e => new EditEventViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId,
                    Types = types
                })
                .FirstOrDefaultAsync();

            return currEvent;
        }

        public async Task EditEventAsync(int id, EditEventViewModel eventModel)
        {
            var currEvent = await dbContext
                .Events
                .FindAsync(id);

            if (currEvent != null)
            {
                currEvent.Name = eventModel.Name;
                currEvent.Description = eventModel.Description;
                currEvent.Start = eventModel.Start;
                currEvent.End = eventModel.End;
                currEvent.TypeId = eventModel.TypeId;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task AddToJoinedEventsAsync(string userId, int id)
        {
            var eventModel = new EventParticipant()
            {
                EventId = id,
                HelperId = userId
            };

            bool isAlreadyAdded = await dbContext
                .EventsParticipants
                .AnyAsync(ep => ep.EventId == id);

            if (!isAlreadyAdded)
            {
                await dbContext.EventsParticipants.AddAsync(eventModel);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task RemoveFromJoinedEventsAsync(string userId, int id)
        {
            var currEvent = await dbContext
                .EventsParticipants
                .Where(ep => ep.EventId == id && ep.HelperId==userId)
                .FirstOrDefaultAsync();

            if (currEvent != null)
            {
                dbContext.EventsParticipants.Remove(currEvent);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<DetailsEventViewModel?> GetDetailsEventByIdAsync(int id)
        {
            var currEvent = await dbContext
                .Events
                .Where(e => e.Id == id)
                .Select(e=> new DetailsEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreateOn.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            return currEvent;
        }

    }
}
