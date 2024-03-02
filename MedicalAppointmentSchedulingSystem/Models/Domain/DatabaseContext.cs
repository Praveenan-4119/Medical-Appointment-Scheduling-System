using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStoreMvc.Models.Domain;

namespace MedicalAppointmentSchedulingSystem.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

       
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientDoctor> PatientDoctor { get; set; }
        public DbSet<Schedule> Movie { get; set; }

    }
}
