using Online_Hairdresser.Models.Models.Request.Login;
using Online_Hairdresser.MongoData.Entity;

namespace Online_Hairdresser.Core.IServices;

public interface IRefreshTokenService
{
    Task<RefreshToken> GetAsync(string refreshToken);
    Task<RefreshToken> Create(RefreshTokenMongoRequest request);
}