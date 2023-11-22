using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Request.Login;

namespace Online_Hairdresser.Core.IServices;

public interface IRefreshTokenPostgreService:IRepository<RefreshToken>
{
    Task<RefreshToken> GetAsync(string refreshToken);
    Task Create(RefreshTokenPostgreRequest request);
}