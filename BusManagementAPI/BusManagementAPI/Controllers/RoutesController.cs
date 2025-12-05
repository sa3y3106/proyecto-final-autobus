using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusManagementAPI.Data;
using BusManagementAPI.Models;
using BusManagementAPI.DTOs;

namespace BusManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusRoute>>> GetRoutes()
        {
            try
            {
                var routes = await _context.Routes.ToListAsync();
                return Ok(routes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener las rutas", error = ex.Message });
            }
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusRoute>> GetRoute(int id)
        {
            try
            {
                var route = await _context.Routes.FindAsync(id);

                if (route == null)
                {
                    return NotFound(new { message = "Ruta no encontrada" });
                }

                return Ok(route);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la ruta", error = ex.Message });
            }
        }

        // POST: api/Routes
        [HttpPost]
        public async Task<ActionResult<BusRoute>> PostRoute(RouteDto routeDto)
        {
            try
            {
                var route = new BusRoute
                {
                    RouteName = routeDto.RouteName,
                    Origin = routeDto.Origin,
                    Destination = routeDto.Destination,
                    Distance = routeDto.Distance
                };

                _context.Routes.Add(route);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRoute), new { id = route.Id }, route);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear la ruta", error = ex.Message });
            }
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, RouteDto routeDto)
        {
            try
            {
                var route = await _context.Routes.FindAsync(id);

                if (route == null)
                {
                    return NotFound(new { message = "Ruta no encontrada" });
                }

                route.RouteName = routeDto.RouteName;
                route.Origin = routeDto.Origin;
                route.Destination = routeDto.Destination;
                route.Distance = routeDto.Distance;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Ruta actualizada exitosamente", route });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
                {
                    return NotFound(new { message = "Ruta no encontrada" });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar la ruta", error = ex.Message });
            }
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            try
            {
                var route = await _context.Routes.FindAsync(id);
                if (route == null)
                {
                    return NotFound(new { message = "Ruta no encontrada" });
                }

                _context.Routes.Remove(route);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Ruta eliminada exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar la ruta", error = ex.Message });
            }
        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.Id == id);
        }
    }
}