using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Response.VenueService;

namespace Online_Hairdresser.Core.IServices;

public interface IVenueServicesService:IRepository<VenueService>
{
    Task<List<VenueServiceResponse>> VenueServiceList(int venueId, string baseUri);
}