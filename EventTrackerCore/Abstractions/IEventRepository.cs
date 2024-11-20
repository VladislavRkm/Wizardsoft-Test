
using EventTrackerCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTrackerCore.Abstractions;

public interface IEventRepository
{
    Task<List<Event>> GetAllEventsAsync();
    Task<Event> GetEventByIdAsync(int id);
    Task AddEventAsync(Event @event);
    Task UpdateEventAsync(Event @event);
    Task DeleteEventAsync(int id);
}
