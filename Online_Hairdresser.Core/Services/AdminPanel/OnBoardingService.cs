using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.IServices.AdminPanel;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Response.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Services.AdminPanel
{
    public class OnBoardingService : Repository<Onboarding>, IOnBoardingService
    {
        private readonly IMapper _mapper;
        public OnBoardingService(OnlineHairdresserDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<OnboardingResponse>> OnBoardingList()
        {
            var onBoarding = await FindBy(x => x.IsActive).AsNoTracking().OrderBy(x => x.Id).ToListAsync();
            var mapOnBoarding = _mapper.Map<List<OnboardingResponse>>(onBoarding);
            return mapOnBoarding;
        }


    }
}
