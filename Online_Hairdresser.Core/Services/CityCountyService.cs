using System.Text.Json;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Request.CityCounty;
using Online_Hairdresser.Models.Models.Response.CityCount;

namespace Online_Hairdresser.Core.Services;

public class CityCountyService:Repository<CityCounty>,ICityCountyService
{
    private readonly IHostingEnvironment _hostingEnvironment;
    public CityCountyService(OnlineHairdresserDbContext context, IHostingEnvironment hostingEnvironment) : base(context)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    
    public async Task AddCityCounty()
    {
        var path = _hostingEnvironment.ContentRootPath;
        using FileStream json = File.OpenRead(@$"{path}/wwwroot/files/json/city_county.json");
        List<CityCountyJson> cityCountyJsons = JsonSerializer.Deserialize<List<CityCountyJson>>(json);
        List<CityCounty> cityCounties = new();
        cityCountyJsons.ForEach(x =>
        {
            cityCounties.Add(new CityCounty
            {
                PlateNumber = x.plaka,
                CityName = x.il,
                CountyName = x.ilce,
                Region = x.bolge
            });
        });
        await Context.BulkInsertAsync(cityCounties);
    }

    public async Task<List<CityCountResponse>> GetCityCountyList()
    {
        var cities = await FindBy(x => x.CityName != null)
            .AsNoTracking()
            .GroupBy(x=>x.PlateNumber)
            .Select(x=>new CityCountResponse
            {
                Id = x.Select(x=>x.Id).FirstOrDefault(),
                CityName = x.Select(x=>x.CityName).FirstOrDefault(),
                Counties = x.Select(x=>new CountyResponse
                {
                    CountyName = x.CountyName
                }).ToList()
            })
            .ToListAsync();
        return cities;
    }
}