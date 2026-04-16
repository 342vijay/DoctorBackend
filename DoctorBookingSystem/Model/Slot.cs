namespace DoctorBookingSystem.Model
{
    public class Slot
    {
        public int slotId { get; set; }
        public DateOnly date { get; set; }
        public string time { get; set; }
        public bool isAvailable { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
    }
}
