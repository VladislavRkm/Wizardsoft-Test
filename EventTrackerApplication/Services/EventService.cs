
using EventTrackerCore.Abstractions;
using EventTrackerCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTrackerApplication.Services
{
    public class EventService : IEventService 
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<List<Event>> GetAllEventsAsync()
        {
            return _eventRepository.GetAllEventsAsync();
        }

        public Task<Event> GetEventByIdAsync(int id)
        {
            return _eventRepository.GetEventByIdAsync(id);
        }

        public Task AddEventAsync(Event @event)
        {
            return _eventRepository.AddEventAsync(@event);
        }

        public Task UpdateEventAsync(Event @event)
        {
            return _eventRepository.UpdateEventAsync(@event);
        }

        public Task DeleteEventAsync(int id)
        {
            return _eventRepository.DeleteEventAsync(id);
        }
    }
}
