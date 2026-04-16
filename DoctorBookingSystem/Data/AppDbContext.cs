using Microsoft.EntityFrameworkCore;
using DoctorBookingSystem.Model;
namespace DoctorBookingSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
         public DbSet<Doctor> Doctors { get; set; }
         public DbSet<Slot> Slots { get; set; }
         public DbSet<Appointment> Appointments { get; set; }
    }
}
