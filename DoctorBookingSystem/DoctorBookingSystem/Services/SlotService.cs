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

        public async Task<List<string>> GetSlots(SlotDTO dto)
        {
            return await _context.Slots
                .Where(s => s.doctorId== dto.doctorId
                         && s.date == dto.date
                         && s.isAvailable == true)
                .Select(s => s.time)    
                .ToListAsync();
        }


    }
}
