using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Models.Options;
using Online_Hairdresser.Models.Models.Request.Login;
using Online_Hairdresser.MongoData.Entity;

namespace Online_Hairdresser.Core.Services;

public class RefreshTokenService:IRefreshTokenService
{
    //https://www.youtube.com/watch?v=iWTdJ1IYGtg
    private readonly IMongoCollection<RefreshToken> _playlistCollection;
    private readonly MongoDBSettings _mongoDbSettings;

    public RefreshTokenService(IOptions<MongoDBSettings> mongoDBSettings,IMongoClient mongoClient)
    {
        _mongoDbSettings = mongoDBSettings.Value;
        IMongoDatabase database = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _playlistCollection = database.GetCollection<RefreshToken>(mongoDBSettings.Value.DatabaseName);

    }

    public async Task<RefreshToken> GetAsync(string refreshToken)
    {
        var now = DateTime.Now;
        var refreshTokenResponse =  await _playlistCollection.Find(x=>x.RefreshTokenContent==refreshToken && x.RefreshTokenExpDate>=now).FirstOrDefaultAsync();
        return refreshTokenResponse;
    }
    public async Task<RefreshToken> Create(RefreshTokenMongoRequest request)
    {
        var refreshToken = new RefreshToken();
        refreshToken.UserId = request.UserId;
        refreshToken.RefreshTokenContent = request.RefreshToken;
        refreshToken.RefreshTokenExpDate = request.RefreshExpDate;
        await _playlistCollection.InsertOneAsync(refreshToken);
        return refreshToken;
    }
}