using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Models.Models.Response.Theme;

public class ThemeResponse
{
    public GenderEnum Gender { get; set; }
    public string ColorOne { get; set; }
    public string ColorTwo { get; set; }
    public string ColorThree { get; set; }
}