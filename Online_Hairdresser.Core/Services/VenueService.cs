using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Options;
using Online_Hairdresser.Models.Models.Request.Venue;
using Online_Hairdresser.Models.Models.Response.Venue;

namespace Online_Hairdresser.Core.Services;

public class VenueService : Repository<Venue>, IVenueService
{
    private readonly AppSettings _appSettings;

    public VenueService(OnlineHairdresserDbContext context, IOptions<AppSettings> appSettings) : base(context)
    {
        _appSettings = appSettings.Value;
    }

    public async Task<PaginatedList<VenueResponse>> GetVenueList(VenueListRequest request)
    {
        var query = FindBy(x=>x.Name != null)
            .AsNoTracking();
        if (request.Search is not null)
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{request.Search}%")
                                     || EF.Functions.Like(x.Motto, $"%{request.Search}%")
                                     || EF.Functions.Like(x.Info, $"%{request.Search}%")
                                     || EF.Functions.Like(x.Address, $"%{request.Search}%"));

        if (request.CityCountyId != 0)
            query = query.Where(x => x.CityCountyId == request.CityCountyId);

        if (request.Latitute == 0 && request.Longitute == 0)
        {
            var queryResponse = query.Select(l=>new VenueResponse
            {
                Id = l.Id,
                Info = l.Info,
                Latitute = l.Latitude,
                Longitute = l.Longitude,
                Motto = l.Motto,
                Name = l.Name,
                Distance = 0,
                Image = l.MainImage
            });
            
            return await PaginatedList<VenueResponse>.CreateAsync(queryResponse, request.Page, _appSettings.PageRowLimit);
        }
        var queryDistance = (from l in query
            let rlat1 = Math.PI * l.Latitude / 180
            let rlat2 = Math.PI * request.Latitute / 180
            let theta = request.Longitute - l.Longitude
            let rtheta = Math.PI * theta / 180
            let dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta)
            let dist2 = Math.Acos(dist)
            let dist3 = dist2 * 180 / Math.PI
            let dist4 = dist3 * 60 * 1.1515
            let dist5 = dist4 * 1.609344
            where (l.Latitude > 0 && l.Longitude > 0)
            orderby dist5
            select new VenueResponse
            {
                Id = l.Id,
                Info = l.Info,
                Latitute = l.Latitude,
                Longitute = l.Longitude,
                Motto = l.Motto,
                Name = l.Name,
                Distance = dist5,
                Image = l.MainImage
            });
            
        return await PaginatedList<VenueResponse>.CreateAsync(queryDistance, request.Page, _appSettings.PageRowLimit);
    }
}