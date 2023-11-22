using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Request.Login;

namespace Online_Hairdresser.Core.Services;

public class RefreshTokenPostgreService:Repository<RefreshToken>,IRefreshTokenPostgreService
{
    public RefreshTokenPostgreService(OnlineHairdresserDbContext context) : base(context)
    {
    }

    public async Task<RefreshToken> GetAsync(string refreshToken)
    {
        var now = DateTime.Now;
        var refreshTokenResponse =  await FindBy(x=>x.RefreshTokenContent==refreshToken && x.RefreshTokenExpDate>=now).FirstOrDefaultAsync();
        return refreshTokenResponse;
    }

    public async Task Create(RefreshTokenPostgreRequest request)
    {
        var refreshToken = new RefreshToken();
        refreshToken.UserId = request.UserId;
        refreshToken.RefreshTokenContent = request.RefreshToken;
        refreshToken.RefreshTokenExpDate = request.RefreshExpDate;
        await AddAsync(refreshToken);
    }
}