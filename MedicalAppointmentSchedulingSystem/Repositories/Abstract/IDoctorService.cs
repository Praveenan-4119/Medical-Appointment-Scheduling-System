using MedicalAppointmentSchedulingSystem.Models.Domain;
using MedicalAppointmentSchedulingSystem.Models.DTO;

namespace MedicalAppointmentSchedulingSystem.Repositories.Abstract
{
    public interface IDoctorService
    {
        bool Add(Doctor model);
        bool Update(Doctor model);

        Doctor GetById(int id);
        bool Delete(int id);

        DoctorListVm List(string term = "", bool paging = false, int currentPage = 0);

        //List<int> GetSpecializationByDoctorId(int doctorId);
    }
}
