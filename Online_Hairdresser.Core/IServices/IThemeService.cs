using Online_Hairdresser.Data.Entity;
using Online_Hairdresser.Data.Repository;
using Online_Hairdresser.Models.Models.Response.Theme;

namespace Online_Hairdresser.Core.IServices;

public interface IThemeService: IRepository<Theme>
{
    Task<List<ThemeResponse>> GetThemeList();
}