using System.ComponentModel.DataAnnotations;

namespace DoctorBookingSystem.Model
{
    public class Doctor
    {
        [Key]
        public int doctorId { get; set; }
        public string mode { get; set; }
        
        public string specialization { get; set; }

        public string doctorName { get; set; }
       
        public string address { get; set; }



    }
}
