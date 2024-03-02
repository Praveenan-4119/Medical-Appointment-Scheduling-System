using MedicalAppointmentSchedulingSystem.Models.Domain;

namespace MedicalAppointmentSchedulingSystem.Models.DTO
{
    public class PatientListVm
    {
        public IQueryable<Patient>PatientList { get; set; }

        //public int PageSize { get; set; }
        //public int CurrentPage { get; set; }
        //public int TotalPages { get; set; }
        //public string? Term { get; set; }
    }
}
