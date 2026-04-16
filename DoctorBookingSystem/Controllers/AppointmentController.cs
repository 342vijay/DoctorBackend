using DoctorBookingSystem.DTO;
using DoctorBookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _Service;
        public AppointmentController(AppointmentService service)
        {
            _Service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Book(AppointmentDTO dto)
        {
            var result = await _Service.BookAppointment(dto);

            if (result == "Slot already booked")
                return BadRequest(result);

            return Ok(result);
        }
    }
}
