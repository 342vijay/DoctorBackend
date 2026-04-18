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
     _service = service;
 }

 // GET api/Appointment/mybooking/1
 [HttpGet("mybooking/{patientId}")]
 public async Task<IActionResult> GetMyBookings(int patientId)
 {
     var data = await _service.GetMyBookings(patientId);
     return Ok(data);
 }
 // POST api/Appointment/book
 [HttpPost("book")]
 public async Task<IActionResult> BookAppointment(AppointmentDto dto)
 {
     var result = await _service.BookAppointment(dto);
     return Ok(result);
 }

 // DELETE api/Appointment/delete/5
 [HttpDelete("delete/{appointmentId}")]
 public async Task<IActionResult> DeleteBooking(int appointmentId)
 {
     var result = await _service.DeleteBooking(appointmentId);
     return Ok(result);
 }
    }
}
