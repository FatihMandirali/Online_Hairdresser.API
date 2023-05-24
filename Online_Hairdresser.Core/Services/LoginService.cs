using Online_Hairdresser.Core.Helpers.JWT;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Hairdresser.Models.Exceptions;
using BC = BCrypt.Net.BCrypt;

namespace Online_Hairdresser.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;

        public LoginService(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public async Task<(AccessToken, string)> Login(LoginRequest request)
        {
            var user = await _userService.FindUserByEmailRole(request.Email,request.Role);
            if (user == null)
                throw new ErrorException("login_error");
            var isValidPassword = BC.Verify(request.Password,user.Password);
            if(!isValidPassword)
                throw new ErrorException("login_error");

            var token = _tokenHelper.CreateToken(user.Role, user.Id);
            return (token, String.Empty);
        }
    }
}
