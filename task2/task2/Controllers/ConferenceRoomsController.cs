using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;
using Serilog;

namespace task2.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class ConferenceRoomsController : ControllerBase
    {
        private readonly ConferenceRoomContext _context;

        public ConferenceRoomsController(ConferenceRoomContext context)
        {
            _context = context;
        }

        // GET: api/ConferenceRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConferenceRoom>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/ConferenceRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConferenceRoom>> GetConferenceRoom(int id)
        {
            var conferenceRoom = await _context.Rooms.FindAsync(id);
            if (conferenceRoom == null)
            {
                Log.Warning("404 - Nie znaleziono pokoju");
                return NotFound();
            }

            return conferenceRoom;
        }

        // PUT: api/ConferenceRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConferenceRoom(int id, ConferenceRoom conferenceRoom)
        {
            if (id != conferenceRoom.Number)
            {
                Log.Information("Nie można aktualizować. Nieprawdiłowy numer pokoju");
                return BadRequest();
            }

            _context.Entry(conferenceRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenceRoomExists(id))
                {
                    Log.Information("Nie można aktualizować. Pokój nr" + id + " nie istnieje");
                    return NotFound();
                }
                else
                {
                    Log.Information("Zaktualizowano pokój NR:"+ id);
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ConferenceRooms
        [HttpPost]
        public async Task<ActionResult<ConferenceRoom>> PostConferenceRoom(ConferenceRoom conferenceRoom)
        {
            _context.Rooms.Add(conferenceRoom);
            await _context.SaveChangesAsync();
            Log.Information("Utworzono pokój NR: "+conferenceRoom.Number);
            return CreatedAtAction("GetConferenceRoom", new { id = conferenceRoom.Number }, conferenceRoom);
        }

        // DELETE: api/ConferenceRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConferenceRoom>> DeleteConferenceRoom(int id)
        {
            var conferenceRoom = await _context.Rooms.FindAsync(id);
            if (conferenceRoom == null)
            {
                Log.Information("Nie można usunąć. Pokój nr" + id +" nie istnieje");
                return NotFound();
            }

            _context.Rooms.Remove(conferenceRoom);
            await _context.SaveChangesAsync();

            Log.Information("Usunięto pokój NR: " + id);
            return conferenceRoom;
        }

        private bool ConferenceRoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Number == id);
        }
    }
}
