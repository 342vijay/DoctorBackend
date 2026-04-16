using System.ComponentModel.DataAnnotations;

namespace DoctorBookingSystem.Model
{
    public class Slot
    {
        [Key]
        public int slotId { get; set; }
        public DateOnly date { get; set; }
        public string time { get; set; }
        public bool isAvailable { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
    }
}
