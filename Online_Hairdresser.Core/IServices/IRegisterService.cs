using Online_Hairdresser.Models.Models.Request.UserRegister;

namespace Online_Hairdresser.Core.IServices;

public interface IRegisterService
{
    Task<string> RegisterUser(UserRegisterRequest registerRequest);
}