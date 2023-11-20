using MediSynthFinals.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace MediSynthFinals.Data
{
    public class MediDbContext : DbContext
    //public class MediDbContext : IdentityDbContext<User>
    {
        // Constructor
        public MediDbContext(DbContextOptions<MediDbContext> options) : base(options) { }


        // Add service to Program.cs and context for database creation
        public DbSet<UserSchedule> DoctorSchedules { get; set; }
        public DbSet<PatientCredentials> PatientCredentials { get; set; }
        public DbSet<RecordDiagnosis> RecordDiagnosis { get; set; }
        public DbSet<RecordMedHistory> RecordMedHistory { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }

        public DbSet<UserSchedule> userSchedules { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<DoctorCredentials>().HasData(
        //        new DoctorCredentials()
        //        {
        //            email = "oraya@gmail.com"
        //        },
        //        );
        //}
    }
}
