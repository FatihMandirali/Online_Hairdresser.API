using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Response.VenueService;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User")]
public class VenueServiceController:BaseController
{
   private readonly IVenueServicesService _venueServicesService;

   public VenueServiceController(IVenueServicesService venueServicesService)
   {
      _venueServicesService = venueServicesService;
   }
   
   [HttpGet("{id}")]
   public async Task<BaseResponse<List<VenueServiceResponse>>> List(int id)
   {
      var baseUri = $"{Request.Scheme}://{Request.Host}/";
      var response = await _venueServicesService.VenueServiceList(id,baseUri);
      return new BaseResponse<List<VenueServiceResponse>>(ProcessStatusEnum.Success, null, response);
   }
   
}