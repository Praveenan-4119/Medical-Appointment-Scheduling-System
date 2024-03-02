using MedicalAppointmentSchedulingSystem.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentSchedulingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoctorService  _doctorService;
        public HomeController(IDoctorService doctorService)
        {
            _doctorService = doctorService;     
        }
        public IActionResult Index(string term="", int currentPage = 1)
        {
            var doctors = _doctorService.List(term,true,currentPage);
            return View(doctors);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult DoctorDetail(int doctorId)
        {
            var doctor = _doctorService.GetById(doctorId);
            return View(doctor);
        }
    }
}
