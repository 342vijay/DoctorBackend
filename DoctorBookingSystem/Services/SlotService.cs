using DoctorBookingSystem.Data;
using DoctorBookingSystem.DTO;
using DoctorBookingSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorBookingSystem.Services
{
    public class SlotService
    {
        private readonly AppDbContext _context;
        public SlotService(AppDbContext context)
        {
            _context = context;
        }

        //to get the available slots for a doctor on a specific date

        public async Task<List<string>> GetSlots(SlotDTO dto)
        {
            return await _context.Slots
                .Where(s => s.doctorId == dto.DoctorId
                         && s.date == dto.Date
                         && !s.isAvailable)
                .Select(s => s.time)
                .ToListAsync();
        }


    }
}
