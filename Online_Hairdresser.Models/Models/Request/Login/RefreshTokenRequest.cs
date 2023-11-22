namespace Online_Hairdresser.Models.Models.Request.Login;

public class RefreshTokenRequest
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
public class RefreshTokenMongoRequest
{
    public string RefreshToken { get; set; }
    public int UserId { get; set; }
    public DateTime RefreshExpDate { get; set; }
}
public class RefreshTokenPostgreRequest
{
    public string RefreshToken { get; set; }
    public int UserId { get; set; }
    public DateTime RefreshExpDate { get; set; }
}