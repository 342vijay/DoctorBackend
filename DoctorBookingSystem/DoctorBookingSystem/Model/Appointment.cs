using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorBookingSystem.Model
{
    public class Appointment
    {
        [Key]
        
        public int appointmentId { get; set; }
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int age { get; set; }
        public string issue { get; set; }
        public string speciality { get; set; }
        public int doctorId { get; set; }
        public DateOnly date { get; set; }
        public string slot { get; set; }
    }
}
