namespace Online_Hairdresser.Data.Entity;

public class RefreshToken:AuditableEntity
{
    public int UserId { get; set; }
    
    public string RefreshTokenContent { get; set; }
    
    public DateTime RefreshTokenExpDate{ get; set; }
}