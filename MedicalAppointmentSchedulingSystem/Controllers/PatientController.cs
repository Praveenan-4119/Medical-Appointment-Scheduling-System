using MedicalAppointmentSchedulingSystem.Models.Domain;
using MedicalAppointmentSchedulingSystem.Models.DTO;
using MedicalAppointmentSchedulingSystem.Repositories.Abstract;
using MedicalAppointmentSchedulingSystem.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalAppointmentSchedulingSystem.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IFileService _fileService;
        private readonly IDoctorService _doctorService;
        public PatientController(IDoctorService doctorService,IPatientService patientService,IFileService fileService)
        {
            _patientService = patientService;
            _fileService = fileService;
            _doctorService = doctorService;
            
        }
        public IActionResult Add()
        {
            var model = new Patient();
            model.DoctorList = _doctorService.List().Select(a=> new SelectListItem { Text=a.DoctorName,Value=a.Id.ToString()});
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Patient model)
        {
            model.DoctorList = _doctorService.List().Select(a => new SelectListItem { Text = a.DoctorName, Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            if(model.ImageFile != null) 
            { 
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if(fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.BankSlipImage = imageName;
            }
            var result = _patientService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

         

        public IActionResult PatientList()
        {
            var data = this._patientService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            
            var result = _patientService.Delete(id);                    
            return RedirectToAction(nameof(PatientList));
            
        }

       

    }
}
