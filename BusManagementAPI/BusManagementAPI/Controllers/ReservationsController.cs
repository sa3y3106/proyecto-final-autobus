using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusManagementAPI.Data;
using BusManagementAPI.Models;
using BusManagementAPI.DTOs;

namespace BusManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetReservations()
        {
            try
            {
                var reservations = await _context.Reservations
                    .Include(r => r.Schedule)
                        .ThenInclude(s => s!.Bus)
                    .Include(r => r.Schedule)
                        .ThenInclude(s => s!.Route)
                    .Select(r => new
                    {
                        r.Id,
                        r.ScheduleId,
                        r.PassengerName,
                        r.SeatNumber,
                        r.ReservationDate,
                        Schedule = new
                        {
                            r.Schedule!.Id,
                            BusNumber = r.Schedule.Bus!.BusNumber,
                            RouteName = r.Schedule.Route!.RouteName,
                            Origin = r.Schedule.Route.Origin,
                            Destination = r.Schedule.Route.Destination,
                            r.Schedule.DepartureTime,
                            r.Schedule.ArrivalTime
                        }
                    })
                    .ToListAsync();

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener las reservas", error = ex.Message });
            }
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetReservation(int id)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.Schedule)
                        .ThenInclude(s => s!.Bus)
                    .Include(r => r.Schedule)
                        .ThenInclude(s => s!.Route)
                    .Where(r => r.Id == id)
                    .Select(r => new
                    {
                        r.Id,
                        r.ScheduleId,
                        r.PassengerName,
                        r.SeatNumber,
                        r.ReservationDate,
                        Schedule = new
                        {
                            r.Schedule!.Id,
                            BusNumber = r.Schedule.Bus!.BusNumber,
                            RouteName = r.Schedule.Route!.RouteName,
                            Origin = r.Schedule.Route.Origin,
                            Destination = r.Schedule.Route.Destination,
                            r.Schedule.DepartureTime,
                            r.Schedule.ArrivalTime
                        }
                    })
                    .FirstOrDefaultAsync();

                if (reservation == null)
                {
                    return NotFound(new { message = "Reserva no encontrada" });
                }

                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la reserva", error = ex.Message });
            }
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(ReservationDto reservationDto)
        {
            try
            {
                // Verificar que el horario existe
                var scheduleExists = await _context.Schedules.AnyAsync(s => s.Id == reservationDto.ScheduleId);
                if (!scheduleExists)
                {
                    return BadRequest(new { message = "El horario especificado no existe" });
                }

                // Verificar que el asiento no esté ocupado
                var seatTaken = await _context.Reservations
                    .AnyAsync(r => r.ScheduleId == reservationDto.ScheduleId && r.SeatNumber == reservationDto.SeatNumber);

                if (seatTaken)
                {
                    return BadRequest(new { message = "El asiento ya está reservado para este horario" });
                }

                var reservation = new Reservation
                {
                    ScheduleId = reservationDto.ScheduleId,
                    PassengerName = reservationDto.PassengerName,
                    SeatNumber = reservationDto.SeatNumber,
                    ReservationDate = reservationDto.ReservationDate
                };

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear la reserva", error = ex.Message });
            }
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                var reservation = await _context.Reservations.FindAsync(id);
                if (reservation == null)
                {
                    return NotFound(new { message = "Reserva no encontrada" });
                }

                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Reserva eliminada exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar la reserva", error = ex.Message });
            }
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}