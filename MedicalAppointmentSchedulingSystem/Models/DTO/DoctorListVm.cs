using MedicalAppointmentSchedulingSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalAppointmentSchedulingSystem.Models.DTO
{
    public class DoctorListVm
    {
        public IQueryable<Doctor>DoctorList { get; set; }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }

        public IEnumerable<SelectListItem> Select(Func<Doctor, SelectListItem> selector)
        {
            return DoctorList.Select(selector);
        }
    }
}
