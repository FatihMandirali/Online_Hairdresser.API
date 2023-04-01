using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Data.Entity;

public class Theme: AuditableEntity
{
    public string Name { get; set; }
    public GenderEnum Gender { get; set; }
    public string ColorOne { get; set; }
    public string ColorTwo { get; set; }
    public string ColorThree { get; set; }
}