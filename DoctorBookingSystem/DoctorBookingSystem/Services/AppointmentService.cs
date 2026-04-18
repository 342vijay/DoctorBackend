using DoctorBookingSystem.Data;
using DoctorBookingSystem.DTO;
using DoctorBookingSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorBookingSystem.Services
{
    public class AppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        // Book Appointment
        public async Task<string> BookAppointment(AppointmentDto dto)
        {
            var exists = await _context.Appointments.AnyAsync(a =>
                a.doctorId == dto.doctorId &&
                a.date == dto.date &&
                a.slot == dto.slot);

            if (exists)
                return "Slot already booked";

            var appointment = new Appointment
            {
                patientId = dto.patientId,
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

        // Get My Bookings
        public async Task<List<Appointment>> GetMyBookings(int patientId)
        {
            return await _context.Appointments
                .Where(a => a.patientId == patientId)
                .ToListAsync();
        }

        // Cancel Booking
        public async Task<string> DeleteBooking(int appointmentId)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.appointmentId == appointmentId);

            if (appointment == null)
                return "Booking Not Found";

            var slot = await _context.Slots.FirstOrDefaultAsync(s =>
                s.doctorId == appointment.doctorId &&
                s.date == appointment.date &&
                s.time == appointment.slot);

            if (slot != null)
            {
                slot.isAvailable = true;
            }

            _context.Appointments.Remove(appointment);

            await _context.SaveChangesAsync();

            return "Booking Deleted Successfully";
        }
    }
}