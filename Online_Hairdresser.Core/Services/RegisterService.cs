using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Exceptions;
using Online_Hairdresser.Models.Models.Request.UserRegister;

namespace Online_Hairdresser.Core.Services;

public class RegisterService:IRegisterService
{
    private readonly IUserService _userService;

    public RegisterService(IUserService userService)
    {
        _userService = userService;
    }

    public async Task RegisterUser(UserRegisterRequest registerRequest)
    {
        var user = await _userService.FindAsync(x => x.Email == registerRequest.Email);
        if (user is not null)
            throw  new ErrorException("email_exist");
        user = new User();
        user.Email = registerRequest.Email;
        user.Gender = registerRequest.Gender;
        user.Role = RolesEnum.User;
        user.Name = registerRequest.Name;
        user.Surname = registerRequest.Surname;
        user.NotificationId = registerRequest.NotificationId;
        user.Latitude = registerRequest.Latitude;
        user.Longitude = registerRequest.Longitude;
        user.City = registerRequest.City;
        user.County = registerRequest.County;
        user.Version = registerRequest.Version;
        user.Platform = registerRequest.Platform;
        user.Phone = registerRequest.Phone;
        user.Password = registerRequest.Password;
        await _userService.AddAsync(user);
    }
}