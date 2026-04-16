using DoctorBookingSystem.Data;
using DoctorBookingSystem.DTO;
using DoctorBookingSystem.Model;
namespace DoctorBookingSystem.Services
{
    public class AppointmentService
    {
        private readonly AppDbContext _context;
        public AppointmentService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<string> BookAppointment(AppointmentDto dto)
        {
            var exists = _context.Appointments.Any(a =>
            a.doctorId == dto.doctorId &&
            a.date == dto.date &&
            a.slot == dto.slot
            );
            if (exists)
            {
                return "Slot already booked";
            }
            var appointment = new Appointment
            {
                patientName = dto.patientName,
                age = dto.age,
                issue = dto.issue,
                speciality = dto.speciality,
                doctorId = dto.doctorId,
                date = dto.date,
                slot = dto.slot
            };
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return "Appointment booked successfully";
        }

    }
}