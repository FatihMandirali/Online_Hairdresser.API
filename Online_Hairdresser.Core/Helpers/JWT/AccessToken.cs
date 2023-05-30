using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Helpers.JWT
{
    public class AccessToken
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime RefreshExpirationDate { get; set; }
    }
}
