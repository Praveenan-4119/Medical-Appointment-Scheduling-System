using MovieStoreMvc.Models.Domain;

namespace MovieStoreMvc.Models.DTO
{
    public class ScheduleListVm
    {
        public IQueryable<Schedule> ScheduleList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
