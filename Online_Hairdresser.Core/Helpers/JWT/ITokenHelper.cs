using Online_Hairdresser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Helpers.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(RolesEnum rolesEnum, int id, int cityCountyId = 0);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
