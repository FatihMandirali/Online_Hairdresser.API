using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Data
{
    public class OnlineHairdresserDbContext : DbContext
    {
        public OnlineHairdresserDbContext(DbContextOptions<OnlineHairdresserDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Onboarding> Onboardings { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<CityCounty> CityCounties { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueFile> VenueFiles { get; set; }
        public DbSet<VenueService> VenueServices{ get; set; }
        public DbSet<VenueWorker> VenueWorkers{ get; set; }
        public DbSet<VenueAppointment> VenueAppointments{ get; set; }
        public DbSet<VenueWorkingHour> VenueWorkingHours{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<CityCounty>().HasQueryFilter(u => !u.IsDeleted && u.IsActive);
            modelBuilder.Entity<Venue>().HasQueryFilter(u => !u.IsDeleted && u.IsActive);
            modelBuilder.Entity<VenueFile>().HasQueryFilter(u => !u.IsDeleted && u.IsActive);
            modelBuilder.Entity<VenueService>().HasQueryFilter(u => !u.IsDeleted && u.IsActive);
            modelBuilder.Entity<VenueWorker>().HasQueryFilter(u => !u.IsDeleted && u.IsActive);
            modelBuilder.Entity<VenueAppointment>().HasQueryFilter(u => !u.IsDeleted && u.IsActive);
            modelBuilder.Entity<VenueWorkingHour>().HasQueryFilter(u => !u.IsDeleted && u.IsActive);
            base.OnModelCreating(modelBuilder);
        }
    }
}
