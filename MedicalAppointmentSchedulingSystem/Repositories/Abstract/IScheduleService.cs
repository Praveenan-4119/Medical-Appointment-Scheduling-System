using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Models.DTO;

namespace MovieStoreMvc.Repositories.Abstract
{
    public interface IScheduleService
    {
       bool Add(Schedule model);
       bool Update(Schedule model);
       Schedule GetById(int id);
       bool Delete(int id);
       ScheduleListVm List(string term = "", bool paging = false, int currentPage = 0);
        

    }
}
