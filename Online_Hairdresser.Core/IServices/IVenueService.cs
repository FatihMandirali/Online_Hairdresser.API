using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Request.Venue;
using Online_Hairdresser.Models.Models.Response.Venue;

namespace Online_Hairdresser.Core.IServices;

public interface IVenueService:IRepository<Venue>
{
    Task<PaginatedList<VenueResponse>> GetVenueList(VenueListRequest request,string baseUri);
}