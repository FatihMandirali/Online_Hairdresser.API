using AutoMapper;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Models.Models.Response.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Mapping
{
    public class OnlineHairdresserMapping: Profile
    {
        public OnlineHairdresserMapping()
        {
            CreateMap<OnboardingResponse, Onboarding>().ReverseMap();

        }
    }
}
