using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentSchedulingSystem.Models.Domain
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string? PatientName { get; set; }

        public string? BankSlipImage { get; set; }
        
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? AppointmentTime { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string? Disease { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int>? Doctors { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? DoctorList { get; set; }
        [NotMapped]
        public string? DoctorNames { get; set; }
        [NotMapped]
        public MultiSelectList? MultiDoctorList { get; set; }
    }
}
