using EventTrackerCore.Abstractions;
using EventTrackerCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTrackerDAL.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventTrackerContext _context;

    public EventRepository(EventTrackerContext context)
    {
        _context = context;
    }

    public async Task<List<Event>> GetAllEventsAsync()
    {
        return await _context.Events.Include(e => e.Category).ToListAsync();
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return await _context.Events.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddEventAsync(Event @event)
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEventAsync(Event @event)
    {
        _context.Entry(@event).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int id)
    {
        var @event = await _context.Events.FindAsync(id);
        if (@event != null)
        {
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
        }
    }
}
