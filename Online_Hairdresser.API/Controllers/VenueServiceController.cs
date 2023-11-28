using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Response.VenueService;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User,General")]
public class VenueServiceController:BaseController
{
   private readonly IVenueServicesService _venueServicesService;

   public VenueServiceController(IVenueServicesService venueServicesService)
   {
      _venueServicesService = venueServicesService;
   }
   
   [HttpGet]
   public async Task<BaseResponse<List<VenueServiceResponse>>> List([FromQuery]int? venueId)
   {
      var baseUri = $"{Request.Scheme}://{Request.Host}/";
      var response = await _venueServicesService.VenueServiceList(venueId,baseUri);
      return new BaseResponse<List<VenueServiceResponse>>(ProcessStatusEnum.Success, null, response);
   }
   
}