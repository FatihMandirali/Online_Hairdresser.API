using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using BC = BCrypt.Net.BCrypt;

namespace Online_Hairdresser.API.Extensions.SeedData
{
    public static class SeedData
    {
        public static async Task DatabaseMigrator(this OnlineHairdresserDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();
            await SeedDataCreate(dbContext);
        }
        public static async Task SeedDataCreate(OnlineHairdresserDbContext dbContext)
        {
            if (await dbContext.Users.CountAsync() > 0) return;
            var user = new User
            {
                CreateDate = DateTime.Now,
                Email = "fatih.mandirali@hotmail.com",
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Fatih",
                Password = BC.HashPassword("123456"),
                Phone = "5393551932",
                Surname = "Mandıralı"
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();


            var onboarding = new Onboarding
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Description = "Açıklama",
                ImageUrl = "ımage urll",
                Name = "onboardingg",
                Ordering = 2
            };

            await dbContext.Onboardings.AddAsync(onboarding);
            await dbContext.SaveChangesAsync();



        }
    }
}
