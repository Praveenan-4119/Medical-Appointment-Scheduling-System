using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentSchedulingSystem.Models.Domain
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string? DoctorName { get; set; }
       
        public string? DoctorImage { get; set; }
        [Required]
        public string? DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Specialization { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Experience { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
       
    }
}
