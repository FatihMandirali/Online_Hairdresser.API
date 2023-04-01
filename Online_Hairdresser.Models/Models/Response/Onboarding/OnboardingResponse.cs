using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Models.Models.Response.Onboarding
{
    public class OnboardingResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
