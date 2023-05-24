using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Response.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Hairdresser.Models.Models.Response.Theme;

namespace Online_Hairdresser.Core.Services
{
    public class OnBoardingService : Repository<Onboarding>, IOnBoardingService
    {
        private readonly IMapper _mapper;
        private readonly IThemeService _themeService;
        public OnBoardingService(OnlineHairdresserDbContext context, IMapper mapper, IThemeService themeService) : base(context)
        {
            _mapper = mapper;
            _themeService = themeService;
        }

        public async Task<List<OnboardingResponse>> OnBoardingList()
        {
            var themeList = await _themeService.FindBy(x => x.IsActive).AsNoTracking().ToListAsync();
            var onBoarding = await FindBy(x => x.IsActive).AsNoTracking().OrderBy(x => x.Id).ToListAsync();
            var mapOnBoarding = _mapper.Map<List<OnboardingResponse>>(onBoarding);
            foreach (var item in mapOnBoarding)
            {
                var theme=themeList.FirstOrDefault(y => y.Gender == item.Gender);
                item.Theme = _mapper.Map<ThemeResponse>(theme);
            }
            return mapOnBoarding;
        }


    }
}
