namespace DoctorBookingSystem.DTO
{
    public class AppointmentDto
    {
        public string patientName { get; set; }
        public int age { get; set; }
        public string issue { get; set; }
        public string speciality { get; set; }
        public int doctorId { get; set; }
        public DateOnly date { get; set; }
        public string slot { get; set; }
    }
}

