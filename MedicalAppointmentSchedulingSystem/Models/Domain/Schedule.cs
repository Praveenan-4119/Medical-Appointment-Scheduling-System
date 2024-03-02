using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreMvc.Models.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public string? DoctorName { get; set; }
        [Required]
        public string? Specialization { get; set; }

        public string? DoctorImage { get; set; }  
        [Required]
        public string? Day1 { get; set; }
        [Required]
        public string? Day2 { get; set; }
        [Required]
        public string? Day3 { get; set; }
        [Required]
        public string? Day4 { get; set; }
        [Required]
        public string? Day5 { get; set; }
        [Required]
        public string? Day6 { get; set; }



        [Required]
        public string? Time1 { get; set; }
        [Required]
        public string? Time2 { get; set; }
        [Required]
        public string? Time3 { get; set; }
        [Required]
        public string? Time4 { get; set; }
        [Required]
        public string? Time5 { get; set; }
        [Required]
        public string? Time6 { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
       

    }
}
