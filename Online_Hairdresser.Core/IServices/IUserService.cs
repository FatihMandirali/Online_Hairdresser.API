using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Core.IServices;

public interface IUserService:IRepository<User>
{
    Task<User> FindUserByEmailRole(string email, RolesEnum role);
}