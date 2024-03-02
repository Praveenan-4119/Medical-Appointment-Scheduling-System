using MedicalAppointmentSchedulingSystem.Models.Domain;
using MedicalAppointmentSchedulingSystem.Models.DTO;

namespace MedicalAppointmentSchedulingSystem.Repositories.Abstract
{
    public interface IPatientService
    {
        bool Add(Patient model);
        bool Update(Patient model);

        Patient GetById(int id);
        bool Delete(int id);

        PatientListVm List(string term = "", bool paging = false, int currentPage = 0);

        List<int> GetDoctorByPatientId(int doctorId);
    }
}
