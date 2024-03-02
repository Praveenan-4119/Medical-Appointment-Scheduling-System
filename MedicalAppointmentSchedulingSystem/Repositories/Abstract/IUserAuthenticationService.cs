using MedicalAppointmentSchedulingSystem.Models.DTO;

namespace MedicalAppointmentSchedulingSystem.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();
    }
}
