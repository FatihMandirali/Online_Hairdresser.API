using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Core.Services;

public class UserService:Repository<User>,IUserService
{
    public UserService(OnlineHairdresserDbContext context) : base(context)
    {
    }

    public async Task<User> FindUserByEmailRole(string email, RolesEnum role)
    {
        var user = await FindAsync(x => x.IsActive && x.Email == email && x.Role == role);
        return user;
    }
}