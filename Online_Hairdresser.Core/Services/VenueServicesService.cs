using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Response.VenueService;

namespace Online_Hairdresser.Core.Services;

public class VenueServicesService : Repository<Data.Entity.VenueService>, IVenueServicesService
{
    public VenueServicesService(OnlineHairdresserDbContext context) : base(context)
    {
    }

    public async Task<List<VenueServiceResponse>> VenueServiceList(int? venueId, string baseUri)
    {
        if (venueId is null)
        {
            var venueServiceResponses = await Context.Services.Where(x => x.IsActive)
                .Select(x => new VenueServiceResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = $"{baseUri}{x.Image}"
                }).ToListAsync();
            return venueServiceResponses;
        }

        var res = await FindBy(x => x.VenueId == venueId)
            .Include(x => x.Service)
            .Select(x => new VenueServiceResponse
            {
                Id = x.Id,
                Name = x.Service.Name,
                Image = $"{baseUri}{x.Service.Image}",
                Price = x.Price
            }).ToListAsync();

        return res;
    }
}