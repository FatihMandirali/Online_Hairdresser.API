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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
