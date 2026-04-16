using DoctorBookingSystem.DTO;
using DoctorBookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {

        private readonly SlotService _service;

        public SlotController(SlotService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetSlots( SlotDTO dto)
        {
            var result = await _service.GetSlots(dto);
            return Ok(result);
        }
    }
}
