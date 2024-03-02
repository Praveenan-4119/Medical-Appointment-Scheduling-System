using MedicalAppointmentSchedulingSystem.Repositories.Abstract;
using MedicalAppointmentSchedulingSystem.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly IFileService _fileService;
        public ScheduleController(IScheduleService ScheduleService, IFileService fileService)
        {
            _scheduleService = ScheduleService;
            _fileService = fileService;
        }
        public IActionResult Add()
        {
            var model = new Schedule();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Schedule model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.DoctorImage = imageName;
            }
            var result = _scheduleService.Add(model);
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
            var model = _scheduleService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Schedule model)
        {

            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.DoctorImage = imageName;
            }
            var result = _scheduleService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(ScheduleList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult ScheduleList(string term = "", int currentPage = 1)
        {
            var data = this._scheduleService.List(term, true, currentPage);
            return View(data);
        }





        public IActionResult Delete(int id)
        {
            var result = _scheduleService.Delete(id);
            return RedirectToAction(nameof(ScheduleList));
        }




    }
}
