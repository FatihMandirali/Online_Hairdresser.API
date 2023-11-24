using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Response.CityCount;

namespace Online_Hairdresser.Core.IServices;

public interface ICityCountyService:IRepository<CityCounty>
{
    Task AddCityCounty();
    Task<List<CityCountResponse>> GetCityCountyList();
}