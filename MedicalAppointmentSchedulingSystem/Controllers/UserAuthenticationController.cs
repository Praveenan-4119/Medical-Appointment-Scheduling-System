using MedicalAppointmentSchedulingSystem.Models.DTO;
using MedicalAppointmentSchedulingSystem.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSchedulingSystem.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        /* We will create a user with admin rights, after that we are going
          to comment this method because we need only
          one user in this application 
          If you need other users ,you can implement this registration method with view
          I have create a complete tutorial for this, you can check the link in description box
         */

        //public IActionResult Registration()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Registration(RegistrationModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);
        //    model.Role = "user";
        //    var result = await authService.RegistrationAsync(model);
        //    TempData["msg"] = result.Message;
        //    return RedirectToAction(nameof(Registration));
        //}

        public IActionResult RegistrationPatient()
        {
            return View();
        }
        //Patient
        [HttpPost]
        public async Task<IActionResult> RegistrationPatient(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.Role = "Patient";
            var result = await authService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(RegistrationPatient));
        }

        public IActionResult RegistrationDoctor()
        {
            return View();
        }

        //Doctor
        [HttpPost]
        public async Task<IActionResult> RegistrationDoctor(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.Role = "Doctor";
            var result = await authService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(RegistrationDoctor));
        }

        public async Task<IActionResult> Register()
        {
            var model = new RegistrationModel
            {
                Email = "admin@gmail.com",
                Username = "admin",
                Name = "Praveenan",
                Password = "Admin@123",
                PasswordConfirm = "Admin@123",
                Role = "Admin"
            };
            // if you want to register with user , Change Role="User"
            var result = await authService.RegistrationAsync(model);
            return Ok(result.Message);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }



    }
}
