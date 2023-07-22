using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Models.Enums;
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
                Surname = "Mandıralı",
                City = "İstanbul",
                County = "Küçükçekmece",
                Latitude = "123.123",
                Longitude = "123.123",
                Gender = GenderEnum.MALE,
                NotificationId = "ddd",
                Version = "1.1.1",
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();


            var onboarding = new Onboarding
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Description = "Çevrendeki en popüler erkek kuaförleri bir tık uzağında!",
                ImageUrl = "images/onboarding/men.png",
                Name = "MALE",
                Ordering = 1,
                Gender = GenderEnum.MALE
            };

            await dbContext.Onboardings.AddAsync(onboarding);
            await dbContext.SaveChangesAsync();
            var onboarding1 = new Onboarding
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Description = "Çevrendeki en popüler bayan kuaförleri bir tık uzağında!",
                ImageUrl = "images/onboarding/women.png",
                Name = "WOMEN",
                Ordering = 2,
                Gender = GenderEnum.WOMAN
            };

            await dbContext.Onboardings.AddAsync(onboarding1);
            await dbContext.SaveChangesAsync();

            var theme = new Theme
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Erkek Theme",
                Gender = GenderEnum.MALE,
                ColorOne = "#000000",
                ColorTwo = "#111111",
                ColorThree = "#222222",
            };
            await dbContext.Themes.AddAsync(theme);
            await dbContext.SaveChangesAsync();

        }
    }
}
