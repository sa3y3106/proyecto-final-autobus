using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusManagementAPI.Data;
using BusManagementAPI.Models;
using BusManagementAPI.DTOs;

namespace BusManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
            try
            {
                var buses = await _context.Buses.ToListAsync();
                return Ok(buses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los autobuses", error = ex.Message });
            }
        }

        // GET: api/Buses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            try
            {
                var bus = await _context.Buses.FindAsync(id);

                if (bus == null)
                {
                    return NotFound(new { message = "Autobús no encontrado" });
                }

                return Ok(bus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el autobús", error = ex.Message });
            }
        }

        // POST: api/Buses
        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus(BusDto busDto)
        {
            try
            {
                var bus = new Bus
                {
                    BusNumber = busDto.BusNumber,
                    Model = busDto.Model,
                    Capacity = busDto.Capacity,
                    Year = busDto.Year,
                    Status = busDto.Status
                };

                _context.Buses.Add(bus);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBus), new { id = bus.Id }, bus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el autobús", error = ex.Message });
            }
        }

        // PUT: api/Buses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(int id, BusDto busDto)
        {
            try
            {
                var bus = await _context.Buses.FindAsync(id);

                if (bus == null)
                {
                    return NotFound(new { message = "Autobús no encontrado" });
                }

                bus.BusNumber = busDto.BusNumber;
                bus.Model = busDto.Model;
                bus.Capacity = busDto.Capacity;
                bus.Year = busDto.Year;
                bus.Status = busDto.Status;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Autobús actualizado exitosamente", bus });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
                {
                    return NotFound(new { message = "Autobús no encontrado" });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el autobús", error = ex.Message });
            }
        }

        // DELETE: api/Buses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {
            try
            {
                var bus = await _context.Buses.FindAsync(id);
                if (bus == null)
                {
                    return NotFound(new { message = "Autobús no encontrado" });
                }

                _context.Buses.Remove(bus);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Autobús eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el autobús", error = ex.Message });
            }
        }

        private bool BusExists(int id)
        {
            return _context.Buses.Any(e => e.Id == id);
        }
    }
}