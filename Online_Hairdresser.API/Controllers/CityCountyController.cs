using Microsoft.AspNetCore.Mvc;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Response.CityCount;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityCountyController:BaseController
{
    private readonly ICityCountyService _cityCountyService;

    public CityCountyController(ICityCountyService cityCountyService)
    {
        _cityCountyService = cityCountyService;
    }

    // [HttpGet("AddCityCounty")]
    // public async Task<IActionResult> AddCityCounty()
    // {
    //     await _cityCountyService.AddCityCounty();
    //     return Ok();
    // }
    
    [HttpGet]
    public async Task<BaseResponse<List<CityCountResponse>>> GetCityCountyList()
    {
        var response = await _cityCountyService.GetCityCountyList();
        return new BaseResponse<List<CityCountResponse>>(ProcessStatusEnum.Success, null, response);
    }
}