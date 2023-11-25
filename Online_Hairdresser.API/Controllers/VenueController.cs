using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Request.Venue;
using Online_Hairdresser.Models.Models.Response.Venue;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User")]
public class VenueController:BaseController
{
    private readonly IVenueService _venueService;

    public VenueController(IVenueService venueService)
    {
        _venueService = venueService;
    }
    
    [HttpGet("GetVenueList")]
    public async Task<BaseResponse<PaginatedList<VenueResponse>>> GetVenueList([FromQuery] VenueListRequest request)
    {
        var baseUri = $"{Request.Scheme}://{Request.Host}/";
        var response = await _venueService.GetVenueList(request,baseUri);
        return new BaseResponse<PaginatedList<VenueResponse>>(ProcessStatusEnum.Success, null, response);
    }
}