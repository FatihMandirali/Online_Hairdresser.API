using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Data.Entity
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public GenderEnum Gender { get; set; }
        public RolesEnum Role { get; set; }
    }
}
