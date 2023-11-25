using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Exceptions;
using Online_Hairdresser.Models.Models.Request.Venue;

namespace Online_Hairdresser.Core.Services;

public class UserFavoriteVenueService:Repository<UserFavoriteVenue>,IUserFavoriteVenueService
{
    public UserFavoriteVenueService(OnlineHairdresserDbContext context) : base(context)
    {
        
    }
    
    public async Task CreateUserFavoriteVenue(UserFavoriteVenueRequest request, int userId)
    {
        var userFavoriteVenue = await FindBy(x=>x.UserId == userId && x.VenueId == request.VenueId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        
        if (userFavoriteVenue is not null)
            throw new ErrorException("already_favorite");

        userFavoriteVenue = new UserFavoriteVenue
        {
            UserId = userId,
            VenueId = request.VenueId
        };
        await AddAsync(userFavoriteVenue);
    }
    
    public async Task DeleteUserFavoriteVenue(UserFavoriteVenueRequest request, int userId)
    {
        var userFavoriteVenue = await FindBy(x=>x.UserId == userId && x.VenueId == request.VenueId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        
        if (userFavoriteVenue is null)
            throw new ErrorException("not_found");

        userFavoriteVenue.IsDeleted = true;
        userFavoriteVenue.IsActive = false;
        await UpdateAsync(userFavoriteVenue, userFavoriteVenue.Id);
    }
    
    public async Task<List<int>> GetUserFavoriteVenue(int userId)
    {
        var userFavoriteVenue = await FindBy(x=>x.UserId == userId)
            .Include(x=>x.Venue)
            .AsNoTracking()
            .Select(x=>x.VenueId)
            .ToListAsync();
        
        return userFavoriteVenue;
    }
}