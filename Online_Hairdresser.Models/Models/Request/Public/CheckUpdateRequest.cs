using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Models.Models.Request.Public;

public class CheckUpdateRequest
{
    public PlatformEnum Platform { get; set; }
    public string Version { get; set; }
}