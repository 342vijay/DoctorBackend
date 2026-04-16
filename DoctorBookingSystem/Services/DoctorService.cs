using DoctorBookingSystem.Data;
using DoctorBookingSystem.DTO;
using DoctorBookingSystem.Model;
using Microsoft.EntityFrameworkCore;
namespace DoctorBookingSystem.Services
{
    public class DoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }
        // to get distinct specialties
        public List<String> GetDistinctSpecialties()
        {
            return _context.Doctors.Select(d => d.specialization).Distinct().ToList();
        }

        //get doctors by specialization and mode
        public async Task<List<Doctor>> GetDoctorsBySpecialtyAndMode(DoctorDTO dto)
        {
            return await _context.Doctors
                .Where(d => d.specialization == dto.specialization && d.mode == dto.mode)
                .ToListAsync();
        }
    }
}
