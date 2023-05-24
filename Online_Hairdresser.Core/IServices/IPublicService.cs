using Online_Hairdresser.Models.Models.Request.Public;

namespace Online_Hairdresser.Core.IServices;

public interface IPublicService
{
    void CheckUpdate(CheckUpdateRequest checkUpdateRequest);
}