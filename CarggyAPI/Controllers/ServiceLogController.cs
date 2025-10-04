using CarggyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarggyAPI.Controllers
{
    [Route("api/ServiceLog")]
    [ApiController]
    public class ServiceLogController : Controller
    {
        public readonly CarggyDBContext _context;

        public ServiceLogController(CarggyDBContext context)
        {
            _context = context;
        }

        //GET: api/ServiceLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceLog>>> GetServiceLogs()
        {
            var serviceLogList = await _context.ServiceLog.ToListAsync();
            return serviceLogList;
        }


        //GET: api/ServiceLog/vehicle/2
        [HttpGet("vehicle/{VehicleId:int}")]
        public async Task<ActionResult<IEnumerable<ServiceLog>>> GetServiceLogsWithVehicleId(int VehicleId)
        {
            var serviceLogList = await _context.ServiceLog
                                    .Where(serviceLog => serviceLog.VehicleId == VehicleId)
                                    .ToListAsync();

            return Ok(serviceLogList);
        }

        //GET: api/ServiceLog/1
        [HttpGet("{ServiceLogId:int}")]
        public async Task<ActionResult<ServiceLog>> GetServiceLogDetails(int ServiceLogId)
        {
            var serviceLogDetails = await _context.ServiceLog.FindAsync(ServiceLogId);

            if(serviceLogDetails == null)
            {
                return NotFound(new { status = 404, message = "Service log not found" });
            }

            return serviceLogDetails;
        }

        //POST: api/ServiceLog
        [HttpPost]
        public async Task<ActionResult<ServiceLog>> PostServiceLog(ServiceLog serviceLog)
        {
            _context.ServiceLog.Add(serviceLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceLogDetails", new { ServiceLogId = serviceLog.ServiceLogId }, serviceLog);
        }

        //PUT: api/ServiceLog/1
        [HttpPut("{ServiceLogId:int}")]
        public async Task<IActionResult> PutServiceLog(int ServiceLogId, ServiceLog serviceLog)
        {
            if(ServiceLogId != serviceLog.ServiceLogId)
            {
                return NotFound(new { status = 404, message = "Service log not found" });
            }

            _context.Entry(serviceLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceLogExists(ServiceLogId))
                {
                    return NotFound(new { status = 404, message = "Service log not found" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { status = 200, message = "Service log updated successfully." });
        }

        //DELETE: api/ServiceLog/1
        [HttpDelete("{ServiceLogId:int}")]
        public async Task<IActionResult> DeleteServiceLog(int ServiceLogId)
        {
            var serviceLog = await _context.ServiceLog.FindAsync(ServiceLogId);
            if (serviceLog == null)
            {
                return NotFound(new { status = 404, message = "Service log not found" });
            }

            _context.ServiceLog.Remove(serviceLog);
            await _context.SaveChangesAsync();

            return Ok(new { status = 200, message = "Service log deleted successfully." });
        }

        private bool ServiceLogExists(int ServiceLogId) =>
           _context.ServiceLog.Any(e => e.ServiceLogId == ServiceLogId);
    }
}
