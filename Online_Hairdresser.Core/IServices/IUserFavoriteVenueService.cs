using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Request.Venue;

namespace Online_Hairdresser.Core.IServices;

public interface IUserFavoriteVenueService:IRepository<UserFavoriteVenue>
{
    Task CreateUserFavoriteVenue(UserFavoriteVenueRequest request, int userId);
    Task DeleteUserFavoriteVenue(UserFavoriteVenueRequest request, int userId);
    Task<List<int>> GetUserFavoriteVenue(int userId);
}