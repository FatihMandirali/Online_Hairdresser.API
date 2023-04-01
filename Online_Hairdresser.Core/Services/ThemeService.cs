using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Data;
using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Response.Theme;

namespace Online_Hairdresser.Core.Services;

public class ThemeService: Repository<Theme>, IThemeService
{
    private readonly IMapper _mapper;
    public ThemeService(OnlineHairdresserDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public async Task<List<ThemeResponse>> GetThemeList()
    {
        var themeList = await FindBy(x => x.IsActive).AsNoTracking().ToListAsync();
        var mapTheme = _mapper.Map<List<ThemeResponse>>(themeList);
        return mapTheme;
    }
}