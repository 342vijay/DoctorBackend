using DoctorBookingSystem.DTO;
using DoctorBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Get distinct specialties
        [HttpGet("speciality")]
        public IActionResult GetSpecialties()
        {
            var specialties = _doctorService.GetDistinctSpecialties();
            return Ok(specialties);
        }

        // Get doctors by specialty and mode
        [HttpPost("doctor")]
        public IActionResult GetDoctorsBySpecialtyAndMode(DoctorDTO dto)
        {
            var doctors = _doctorService.GetDoctorsBySpecialtyAndMode(dto);
            return Ok(doctors);
        }
    }
}
