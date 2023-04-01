using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Models.Models.Request.UserRegister;

public class UserRegisterRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public GenderEnum Gender { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string Email { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public PlatformEnum Platform { get; set; }
    public string Version { get; set; }
    public string NotificationId { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}