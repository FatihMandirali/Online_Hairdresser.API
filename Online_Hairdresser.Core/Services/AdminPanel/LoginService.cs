using Online_Hairdresser.Core.Helpers.JWT;
using Online_Hairdresser.Core.IServices.AdminPanel;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Services.AdminPanel
{
    public class LoginService : ILoginService
    {
        private readonly ITokenHelper _tokenHelper;

        public LoginService(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        public async Task<(AccessToken, string)> Login(LoginRequest request)
        {
            var token = _tokenHelper.CreateToken(RolesEnum.Admin, 12);
            return (token, null);
        }
    }
}
