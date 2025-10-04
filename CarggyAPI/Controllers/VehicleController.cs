using CarggyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarggyAPI.Controllers
{
    [Route("api/Vehicle")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly CarggyDBContext _context;

        public VehicleController(CarggyDBContext context)
        {
            _context = context;
        }

        //GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            var vehicleList = await _context.Vehicle.ToListAsync();
            return vehicleList;
        }

        //GET: api/Vehicle/{firebaseUserId}
        [HttpGet("{UserId}")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesWithUserId(string UserId)
        {
            var vehicleList = await _context.Vehicle
                                .Where(vehicle => vehicle.UserId == UserId)
                                .ToListAsync();

            return Ok(vehicleList);
        }

        //GET: api/Vehicle/1
        [HttpGet("{VehicleId:int}")]
        public async Task<ActionResult<Vehicle>> GetVehicleDetails(int VehicleId)
        {
            var vehicleDetails = await _context.Vehicle.FindAsync(VehicleId);

            if (vehicleDetails == null)
            {
                return NotFound(new { status = 404, message = "Vehicle not found" });
            }

            return vehicleDetails;
        }

        //POST: api/Vehicle
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            _context.Vehicle.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleDetails", new { VehicleId = vehicle.VehicleId }, vehicle);
        }

        //PUT: api/Vehicle/1
        [HttpPut("{VehicleId:int}")]
        public async Task<IActionResult> PutVehicle( int VehicleId, Vehicle vehicle)
        {
            if(VehicleId != vehicle.VehicleId)
            {
                return NotFound(new { status = 404, message = "Vehicle not found" });
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!VehicleExists(VehicleId))
                {
                    return NotFound(new { status = 404, message = "Vehicle not found" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { status = 200, message = "Vehicle updated successfully." });
        }

        //DELETE: api/Vehicle/1
        [HttpDelete("{VehicleId:int}")]
        public async Task<IActionResult> DeleteVehicle(int VehicleId)
        {
            var vehicle = await _context.Vehicle.FindAsync(VehicleId);
            if (vehicle == null)
            {
                return NotFound(new { status = 404, message = "Vehicle not found" });
            }

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(new { status = 200, message = "Vehicle deleted successfully." });
        }

        private bool VehicleExists(int VehicleId) =>
            _context.Vehicle.Any(e => e.VehicleId == VehicleId);

    }
}
