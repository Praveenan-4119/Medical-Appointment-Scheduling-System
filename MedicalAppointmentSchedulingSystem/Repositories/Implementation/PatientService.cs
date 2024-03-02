using MedicalAppointmentSchedulingSystem.Models.Domain;
using MedicalAppointmentSchedulingSystem.Models.DTO;
using MedicalAppointmentSchedulingSystem.Repositories.Abstract;

namespace MedicalAppointmentSchedulingSystem.Repositories.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly DatabaseContext ctx;

        public PatientService(DatabaseContext ctx)
        {
            this.ctx = ctx;   
        }
        public bool Add(Patient model)
        {
            try
            {
                ctx.Patient.Add(model);
                ctx.SaveChanges();
                foreach(int DoctorId in model.Doctors)
                {
                    var PatientDoctor = new PatientDoctor
                    {
                        PatientId = model.Id,
                        DoctorId = DoctorId
                    };
                    ctx.PatientDoctor.Add(PatientDoctor);
                }
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
                if(data == null)
                    return false;
                var PatientDoctors = ctx.PatientDoctor.Where(a => a.PatientId == data.Id);
                foreach(var PatientDoctor in PatientDoctors)
                {
                    ctx.PatientDoctor.Remove(PatientDoctor);
                }
                ctx.Patient.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Patient GetById(int id)
        {
            return ctx.Patient.Find(id);
        }

        public PatientListVm List(string term="",bool paging=false, int currentPage=0)
        {
            var data = new PatientListVm();

            var list = ctx.Patient.ToList();           
            
            if(!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a=>a.PatientName.ToLower().StartsWith(term)).ToList();
            }

           

            foreach (var Patient in list)
            {
                var Doctors = (from Doctor in ctx.Doctor join mg in ctx.PatientDoctor
                                       on Doctor.Id equals mg.DoctorId
                                       where mg.PatientId== Patient.Id
                                       select Doctor.DoctorName
                                       ).ToList();
                var DoctorNames = string.Join(',', Doctors);
                Patient.DoctorNames = DoctorNames;
            }
            data.PatientList = list.AsQueryable();
            return data;    
        }

        public bool Update(Patient model)
        {
            try
            {
                var DoctorToDeleted = ctx.PatientDoctor.Where(a => a.PatientId == model.Id && !model.Doctors.Contains(a.DoctorId)).ToList();
                foreach(var PatientDoctor in DoctorToDeleted)
                {
                    ctx.PatientDoctor.Remove(PatientDoctor);
                }
                foreach (int speciId in model.Doctors)
                {
                    var PatientDoctor = ctx.PatientDoctor.FirstOrDefault(a => a.PatientId == model.Id && a.DoctorId == speciId);
                    if (PatientDoctor == null)
                    {
                        PatientDoctor = new PatientDoctor { DoctorId = speciId, PatientId = model.Id };
                        ctx.PatientDoctor.Add(PatientDoctor);
                    }
                }
                ctx.Patient.Update(model);
                
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetDoctorByPatientId(int PatientId)
        {
            var DoctorIds = ctx.PatientDoctor.Where(a=>a.PatientId==PatientId).Select(a=>a.DoctorId).ToList();
            return DoctorIds;
        }

       
    }
}
