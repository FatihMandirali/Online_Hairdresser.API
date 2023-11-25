using AutoMapper;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Models.Models.Response.Onboarding;
using Online_Hairdresser.Models.Models.Response.Theme;

namespace Online_Hairdresser.Core.Mapping
{
    public class OnlineHairdresserMapping: Profile
    {
        public OnlineHairdresserMapping()
        {
            CreateMap<OnboardingResponse, Onboarding>().ReverseMap();
            CreateMap<ThemeResponse, Theme>().ReverseMap();

        }
    }
}
