using MedicalAppointmentSchedulingSystem.Models.Domain;
using MedicalAppointmentSchedulingSystem.Repositories.Abstract;
using MedicalAppointmentSchedulingSystem.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalAppointmentSchedulingSystem.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IFileService _fileService;
        
        public DoctorController(IDoctorService DoctorService,IFileService fileService)
        {
            _doctorService = DoctorService;
            _fileService = fileService;
           
        }
        public IActionResult Add()
        {
            var model = new Doctor();
            return View(model);
        }


        [HttpPost]
        public IActionResult Add(Doctor model)
        {
           
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
                model.DoctorImage = imageName;
            }
            var result = _doctorService.Add(model);
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

        public IActionResult Edit(int id)
        {
            var model = _doctorService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Doctor model)
        {
           
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.DoctorImage = imageName;
            }
            var result = _doctorService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(DoctorList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult DoctorList()
        {
            var data = this._doctorService.List();
            return View(data);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            
            var result = _doctorService.Delete(id);                    
            return RedirectToAction(nameof(DoctorList));
            
        }

       

    }
}
