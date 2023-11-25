using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.Request.CityCounty;
using BC = BCrypt.Net.BCrypt;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

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
            
            string path =  $"{Directory.GetCurrentDirectory()}{@"/wwwroot/files/json/city_county.json"}";
            using FileStream json = File.OpenRead(path);
            List<CityCountyJson> cityCountyJsons = JsonSerializer.Deserialize<List<CityCountyJson>>(json);
            List<CityCounty> cityCounties = new();
            cityCountyJsons.ForEach(x =>
            {
                cityCounties.Add(new CityCounty
                {
                    PlateNumber = x.plaka,
                    CityName = x.il,
                    CountyName = x.ilce,
                    Region = x.bolge,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                });
            });
            
            await dbContext.CityCounties.AddRangeAsync(cityCounties);
            await dbContext.SaveChangesAsync();

            var venue = new Venue
            {
                Name = "FM Kuaför",
                Address = "Küçükçekmece",
                CityCountyId = 1,
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Phone = "5393551932",
                Latitude = 123.123,
                Longitude = 123.123,
                Info = "FM Kuaför Hizmetinizde",
                Motto = "Bay&Bayan Kuaför",
                ProcessInterval = 30,
            };
            await dbContext.Venues.AddAsync(venue);
            await dbContext.SaveChangesAsync();
            
            var venueService = new VenueService
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Saç Kesimi",
                Price = 50,
                VenueId = venue.Id
            };
            await dbContext.VenueServices.AddAsync(venueService);
            await dbContext.SaveChangesAsync();
            
            var venueService1 = new VenueService
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Sakal Kesimi",
                Price = 30,
                VenueId = venue.Id
            };
            await dbContext.VenueServices.AddAsync(venueService1);
            await dbContext.SaveChangesAsync();
            
            var venueWorker = new VenueWorker
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Fatih",
                Surname = "Mandıralı",
                Phone = "5393551932",
                VenueId = venue.Id,
                Email = "fatih.mandirali@hotmail.com",
                ServiceList = "1,2"
            };  
            
            await dbContext.VenueWorkers.AddAsync(venueWorker);
            await dbContext.SaveChangesAsync();
            
            var venueWorker1 = new VenueWorker
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Name = "Enes",
                Surname = "İleri",
                Phone = "4443332233",
                VenueId = venue.Id,
                Email = "enes.ileri@hotmail.com",
                ServiceList = "1,2"
            };
            await dbContext.VenueWorkers.AddAsync(venueWorker1);
            await dbContext.SaveChangesAsync();
            
            var venueWorkingHour = new VenueWorkingHour
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Day = DayOfWeekEnum.Monday,
                StartHour = new TimeSpan(9,0,0),
                EndHour = new TimeSpan(18,0,0),
                VenueId = venue.Id
            };
            await dbContext.VenueWorkingHours.AddAsync(venueWorkingHour);
            await dbContext.SaveChangesAsync();
            
            var venueWorkingHour1 = new VenueWorkingHour
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Day = DayOfWeekEnum.Tuesday,
                StartHour = new TimeSpan(9,0,0),
                EndHour = new TimeSpan(18,0,0),
                VenueId = venue.Id
            };
            await dbContext.VenueWorkingHours.AddAsync(venueWorkingHour1);
            await dbContext.SaveChangesAsync();
            
            var venueWorkingHour2 = new VenueWorkingHour
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Day = DayOfWeekEnum.Wednesday,
                StartHour = new TimeSpan(9,0,0),
                EndHour = new TimeSpan(18,0,0),
                VenueId = venue.Id
            };
            await dbContext.VenueWorkingHours.AddAsync(venueWorkingHour2);
            await dbContext.SaveChangesAsync();
            
            var venueWorkingHour3 = new VenueWorkingHour
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Day = DayOfWeekEnum.Thursday,
                StartHour = new TimeSpan(9,0,0),
                EndHour = new TimeSpan(18,0,0),
                VenueId = venue.Id
            };
            await dbContext.VenueWorkingHours.AddAsync(venueWorkingHour3);
            await dbContext.SaveChangesAsync();
            
            var venueWorkingHour4 = new VenueWorkingHour
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Day = DayOfWeekEnum.Friday,
                StartHour = new TimeSpan(9,0,0),
                EndHour = new TimeSpan(18,0,0),
                VenueId = venue.Id
            };
            await dbContext.VenueWorkingHours.AddAsync(venueWorkingHour4);
            await dbContext.SaveChangesAsync();
            
            var venueWorkingHour5 = new VenueWorkingHour
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Day = DayOfWeekEnum.Saturday,
                StartHour = new TimeSpan(9,0,0),
                EndHour = new TimeSpan(18,0,0),
                VenueId = venue.Id
            };
            await dbContext.VenueWorkingHours.AddAsync(venueWorkingHour5);
            await dbContext.SaveChangesAsync();
            
            var venueWorkingHour6 = new VenueWorkingHour
            {
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Day = DayOfWeekEnum.Sunday,
                StartHour = new TimeSpan(9,0,0),
                EndHour = new TimeSpan(18,0,0),
                VenueId = venue.Id
            };
            await dbContext.VenueWorkingHours.AddAsync(venueWorkingHour6);
            await dbContext.SaveChangesAsync();
            
            
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
                CityCountyId = 1,
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
