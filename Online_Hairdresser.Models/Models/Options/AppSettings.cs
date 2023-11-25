namespace Online_Hairdresser.Models.Models.Options;

public class AppSettings
{
    public Version IosMajorVersion { get; set; }
    public Version IosMinorVersion { get; set; }
    public Version AndroidMajorVersion { get; set; }
    public Version AndroidMinorVersion { get; set; }
    public int PageRowLimit { get; set; }
}