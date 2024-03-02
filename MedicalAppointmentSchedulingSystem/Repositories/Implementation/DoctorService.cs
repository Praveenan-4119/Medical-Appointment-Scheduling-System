using MedicalAppointmentSchedulingSystem.Models.Domain;
using MedicalAppointmentSchedulingSystem.Models.DTO;
using MedicalAppointmentSchedulingSystem.Repositories.Abstract;

namespace MedicalAppointmentSchedulingSystem.Repositories.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly DatabaseContext ctx;

        public DoctorService(DatabaseContext ctx)
        {
            this.ctx = ctx;   
        }
        public bool Add(Doctor model)
        {
            try
            {
                ctx.Doctor.Add(model);
                ctx.SaveChanges();
                //foreach(int specializationId in model.Specializations)
                //{
                //    var doctorSpecialization = new DoctorSpecialization
                //    {
                //        DoctorId = model.Id,
                //        SpecializationId = specializationId
                //    };
                //    ctx.DoctorSpecialization.Add(doctorSpecialization);
                //}
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                //var doctorSpecializations = ctx.DoctorSpecialization.Where(a => a.DoctorId == data.Id);
                //foreach (var doctorSpecialization in doctorSpecializations)
                //{
                //    ctx.DoctorSpecialization.Remove(doctorSpecialization);
                //}
                ctx.Doctor.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Doctor GetById(int id)
        {
            return ctx.Doctor.Find(id);
        }

        public DoctorListVm List(string term="",bool paging=false, int currentPage=0)
        {
            var data = new DoctorListVm();

            var list = ctx.Doctor.ToList();           
            
            if(!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a=>a.Specialization.ToLower().StartsWith(term)).ToList();
            }

            if (paging)
            {
                int pageSize = 5;
                int count = list.Count;
                int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                list = list.Skip((currentPage - 1)*pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }

            //foreach (var doctor in list)
            //{
            //    var specializations = (from specialization in ctx.Specialization join mg in ctx.DoctorSpecialization
            //                           on specialization.Id equals mg.SpecializationId
            //                           where mg.DoctorId== doctor.Id
            //                           select specialization.SpecializationName
            //                           ).ToList();
            //    var specializationNames = string.Join(',', specializations);
            //    doctor.SpecializationNames = specializationNames;
            //}
            data.DoctorList = list.AsQueryable();
            return data;    
        }

        public bool Update(Doctor model)
        {
            try
            {
                //var specializationToDeleted = ctx.DoctorSpecialization.Where(a => a.DoctorId == model.Id && !model.Specializations.Contains(a.SpecializationId)).ToList();
                //foreach(var doctorSpecialization in specializationToDeleted)
                //{
                //    ctx.DoctorSpecialization.Remove(doctorSpecialization);
                //}
                //foreach (int speciId in model.Specializations)
                //{
                //    var doctorSpecialization = ctx.DoctorSpecialization.FirstOrDefault(a => a.DoctorId == model.Id && a.SpecializationId == speciId);
                //    if (doctorSpecialization == null)
                //    {
                //        doctorSpecialization = new DoctorSpecialization { SpecializationId = speciId, DoctorId = model.Id };
                //        ctx.DoctorSpecialization.Add(doctorSpecialization);
                //    }
                //}
                ctx.Doctor.Update(model);
                
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public List<int> GetSpecializationByDoctorId(int doctorId)
        //{
        //    var specializationIds = ctx.DoctorSpecialization.Where(a=>a.DoctorId==doctorId).Select(a=>a.SpecializationId).ToList();
        //    return specializationIds;
        //}
    }
}
