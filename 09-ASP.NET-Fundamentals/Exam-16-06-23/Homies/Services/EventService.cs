﻿using Homies.Data;
using Homies.Data.Models;
using Homies.Models.EventModels;
using Homies.Models.TypeModels;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;

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
                .Where(ep=>ep.HelperId == userId)
                .Select(ep=> new AllEventsViewModel
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
                .Select(t=> new TypeViewModel
                {
                    Id= t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            return types;
        }

        public async Task AddNewEventAsync(AddEventViewModel newEvent)
        {
            var currType = await dbContext
                .Types
                .Where(t=> t.Id==newEvent.TypeId)
                .FirstOrDefaultAsync();


            var addEvent = new Event()
            {
                Name = newEvent.Name,
                Description = newEvent.Description,
                Start = newEvent.Start,
                End = newEvent.End,
                TypeId = newEvent.TypeId,
                Type = currType!,
                OrganiserId = newEvent.OrganiserId
            };

            await dbContext.Events.AddAsync(addEvent);
            await dbContext.SaveChangesAsync();

        }

    }
}
