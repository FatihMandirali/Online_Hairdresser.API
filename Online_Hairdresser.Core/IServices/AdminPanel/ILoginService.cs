using Online_Hairdresser.Core.Helpers.JWT;
using Online_Hairdresser.Models.Models.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.IServices.AdminPanel
{
    public interface ILoginService
    {
        Task<(AccessToken, string)> Login(LoginRequest request);
    }
}
