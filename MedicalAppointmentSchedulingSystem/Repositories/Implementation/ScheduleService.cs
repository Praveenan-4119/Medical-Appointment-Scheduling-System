using MedicalAppointmentSchedulingSystem.Models.Domain;
using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Repositories.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly DatabaseContext ctx;
        public ScheduleService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Schedule model)
        {
            try
            {
                
                ctx.Movie.Add(model);
                ctx.SaveChanges();               
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
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
                
                ctx.Movie.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Schedule GetById(int id)
        {
            return ctx.Movie.Find(id);
        }

        public ScheduleListVm List(string term="",bool paging=false, int currentPage=0)
        {
            var data = new ScheduleListVm();
           
            var list = ctx.Movie.ToList();
           
           
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a => a.DoctorName.ToLower().StartsWith(term)).ToList();
            }

          
            data.ScheduleList = list.AsQueryable();
            return data;
        }

        public bool Update(Schedule model)
        {
            try
            {
             
                ctx.Movie.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
       
    }
}
