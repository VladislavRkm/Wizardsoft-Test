
using EventTrackerCore.Abstractions;
using EventTrackerCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _service;

    public EventController(IEventService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Event>>> GetAllEvents()
    {
        var events = await _service.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEventById(int id)
    {
        var @event = await _service.GetEventByIdAsync(id);
        if (@event == null)
        {
            return NotFound();
        }
        return Ok(@event);
    }

    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent(Event @event)
    {
        await _service.AddEventAsync(@event);
        return CreatedAtAction(nameof(GetEventById), new { id = @event.Id }, @event);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, Event @event)
    {
        if (id != @event.Id)
        {
            return BadRequest();
        }

        await _service.UpdateEventAsync(@event);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        await _service.DeleteEventAsync(id);
        return NoContent();
    }
}
