using Microsoft.Extensions.Options;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Exceptions;
using Online_Hairdresser.Models.Models.Options;
using Online_Hairdresser.Models.Models.Request.Public;

namespace Online_Hairdresser.Core.Services;

public class PublicService:IPublicService
{
    private readonly AppSettings _appSettings;

    public PublicService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public void CheckUpdate(CheckUpdateRequest checkUpdateRequest)
    {
        Version version = new Version(checkUpdateRequest.Version);
        
        if (checkUpdateRequest.Platform == PlatformEnum.IOS)
        {
            if (version.CompareTo(_appSettings.IosMajorVersion) < 0)
                throw new CheckUpdateException("MAJOR");
            if (version.CompareTo(_appSettings.IosMinorVersion) < 0)
                throw new CheckUpdateException("MINOR");
        }
        else
        {
            if (version.CompareTo(_appSettings.AndroidMajorVersion) < 0)
                throw new CheckUpdateException("MAJOR");
            if (version.CompareTo(_appSettings.AndroidMinorVersion) < 0)
                throw new CheckUpdateException("MINOR");
        }
    }
}