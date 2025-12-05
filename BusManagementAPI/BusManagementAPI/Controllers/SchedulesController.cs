using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusManagementAPI.Data;
using BusManagementAPI.Models;
using BusManagementAPI.DTOs;

namespace BusManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetSchedules()
        {
            try
            {
                var schedules = await _context.Schedules
                    .Include(s => s.Bus)
                    .Include(s => s.Route)
                    .Select(s => new
                    {
                        s.Id,
                        s.BusId,
                        BusNumber = s.Bus!.BusNumber,
                        BusModel = s.Bus.Model,
                        s.RouteId,
                        RouteName = s.Route!.RouteName,
                        Origin = s.Route.Origin,
                        Destination = s.Route.Destination,
                        s.DepartureTime,
                        s.ArrivalTime
                    })
                    .ToListAsync();

                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los horarios", error = ex.Message });
            }
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetSchedule(int id)
        {
            try
            {
                var schedule = await _context.Schedules
                    .Include(s => s.Bus)
                    .Include(s => s.Route)
                    .Where(s => s.Id == id)
                    .Select(s => new
                    {
                        s.Id,
                        s.BusId,
                        BusNumber = s.Bus!.BusNumber,
                        BusModel = s.Bus.Model,
                        s.RouteId,
                        RouteName = s.Route!.RouteName,
                        Origin = s.Route.Origin,
                        Destination = s.Route.Destination,
                        s.DepartureTime,
                        s.ArrivalTime
                    })
                    .FirstOrDefaultAsync();

                if (schedule == null)
                {
                    return NotFound(new { message = "Horario no encontrado" });
                }

                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el horario", error = ex.Message });
            }
        }

        // POST: api/Schedules
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(ScheduleDto scheduleDto)
        {
            try
            {
                // Verificar que el bus existe
                var busExists = await _context.Buses.AnyAsync(b => b.Id == scheduleDto.BusId);
                if (!busExists)
                {
                    return BadRequest(new { message = "El autobús especificado no existe" });
                }

                // Verificar que la ruta existe
                var routeExists = await _context.Routes.AnyAsync(r => r.Id == scheduleDto.RouteId);
                if (!routeExists)
                {
                    return BadRequest(new { message = "La ruta especificada no existe" });
                }

                var schedule = new Schedule
                {
                    BusId = scheduleDto.BusId,
                    RouteId = scheduleDto.RouteId,
                    DepartureTime = scheduleDto.DepartureTime,
                    ArrivalTime = scheduleDto.ArrivalTime
                };

                _context.Schedules.Add(schedule);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el horario", error = ex.Message });
            }
        }

        // PUT: api/Schedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(int id, ScheduleDto scheduleDto)
        {
            try
            {
                var schedule = await _context.Schedules.FindAsync(id);

                if (schedule == null)
                {
                    return NotFound(new { message = "Horario no encontrado" });
                }

                // Verificar que el bus existe
                var busExists = await _context.Buses.AnyAsync(b => b.Id == scheduleDto.BusId);
                if (!busExists)
                {
                    return BadRequest(new { message = "El autobús especificado no existe" });
                }

                // Verificar que la ruta existe
                var routeExists = await _context.Routes.AnyAsync(r => r.Id == scheduleDto.RouteId);
                if (!routeExists)
                {
                    return BadRequest(new { message = "La ruta especificada no existe" });
                }

                schedule.BusId = scheduleDto.BusId;
                schedule.RouteId = scheduleDto.RouteId;
                schedule.DepartureTime = scheduleDto.DepartureTime;
                schedule.ArrivalTime = scheduleDto.ArrivalTime;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Horario actualizado exitosamente", schedule });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
                {
                    return NotFound(new { message = "Horario no encontrado" });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el horario", error = ex.Message });
            }
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            try
            {
                var schedule = await _context.Schedules.FindAsync(id);
                if (schedule == null)
                {
                    return NotFound(new { message = "Horario no encontrado" });
                }

                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Horario eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el horario", error = ex.Message });
            }
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}